using System;
using System.Data;
using HubDevice.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Npgsql;

namespace HubDevice.Controllers
{
    public class DevicesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly hubdeviceContext _hubDeviceContext;
        public DevicesController(IConfiguration configuration, hubdeviceContext hubDeviceContext)
        {
            _hubDeviceContext = hubDeviceContext;
            _configuration = configuration;
        }

        [HttpGet("get-all")]
        public JsonResult GetFromDb()
        {
            var devices = _hubDeviceContext.Devices.First();

            return new JsonResult(devices);
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"select * from WeatherDevice";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("EmployeeAppCon");
            NpgsqlDataReader myReader;
            using(NpgsqlConnection myCon = new NpgsqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(NpgsqlCommand myCommand = new NpgsqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }
    }
}

