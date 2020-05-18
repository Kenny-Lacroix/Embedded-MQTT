using embedded_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embedded_GUI.Repos
{
    public interface IDeviceRepo
    {
        void Add(Device device);
        void Update(Device device);
        Device GetOne(int id);
        IList<Device> GetAll();
        void Delete(Device device);
    }
}
