using System;
namespace HubDevice.Models
{
    public class WeatherDevice
    {
        public string Name { get; set; }
        public double Temperature { get; set; }
        public WeatherStation Station { get; set; }
    }
}

