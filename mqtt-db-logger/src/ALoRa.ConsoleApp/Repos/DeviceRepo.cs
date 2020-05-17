using ALoRa.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Repos
{
    public class DeviceRepo : IDeviceRepo
    {
        private TTNdbContext context;

        public DeviceRepo(TTNdbContext context)
        {
            this.context = context;
        }

        public void Add(Device device)
        {
            context.Devices.Add(device);
            context.SaveChanges();
            Console.WriteLine("Device added");
        }

        public void Update(Device device)
        {
            context.SaveChanges();
        }
    }
}
