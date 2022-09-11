using System;
namespace HubDevice.Models
{
    public class Station
    {
        public Station()
        {
            Devices = new HashSet<Device>();
        }

        public string Name { get; set; }
        public int? Connecteddevices { get; set; }
        public int Id { get; set; }

        public virtual ICollection<Device> Devices { get; set; }
    }
}

