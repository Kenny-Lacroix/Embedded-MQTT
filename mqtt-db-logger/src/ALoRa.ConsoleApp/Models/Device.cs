using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Models
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public DateTime? LastSeen { get; set; }

        public int AppId { get; set; }
        public Applicatie Applicatie { get; set; }

        public ICollection<Data> Datas { get; set; }
    }
}
