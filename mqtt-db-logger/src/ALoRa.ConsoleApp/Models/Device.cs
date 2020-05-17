using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Models
{
    public class Device
    {
        [Key]
        public int DeviceId { get; set; }
        public string DeviceName { get; set; }
        public DateTime? LastSeen { get; set; }

        [ForeignKey(nameof(Applicatie))]
        public int AppId { get; set; }
        public Applicatie Applicatie { get; set; }

        public ICollection<Data> Datas { get; set; }
    }
}
