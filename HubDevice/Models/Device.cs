using System;
namespace HubDevice.Models
{
    public class Device
    {
        public string Name { get; set; }
        public int? Temperature { get; set; }
        public int Id { get; set; }
        public int? Stationid { get; set; }

        public virtual Station Station { get; set; }
    }
}

