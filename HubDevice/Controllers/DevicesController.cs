using System;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using Npgsql;

namespace HubDevice.Controllers
{
    public class DevicesController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DevicesController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


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

