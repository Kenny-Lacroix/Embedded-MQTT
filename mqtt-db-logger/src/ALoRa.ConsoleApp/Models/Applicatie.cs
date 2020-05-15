using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Models
{
    public class Applicatie
    {
        public int AppId { get; set; }
        public string AppName { get; set; }

        public ICollection<Device> Devices { get; set; }
    }
}
