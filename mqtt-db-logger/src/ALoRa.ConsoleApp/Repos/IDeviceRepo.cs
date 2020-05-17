using ALoRa.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Repos
{
    public interface IDeviceRepo
    {
        void Add(Device device);
        void Update(Device device);
        Device GetOne(string name);
        IList<Device> GetAll();
        void Delete(Device device);
    }
}
