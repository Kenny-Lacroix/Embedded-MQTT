using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Models
{
    public class Data
    {
        [Key]
        public int DataId { get; set; }
        public DateTime? TimeStamp { get; set; }
        public string Payload { get; set; }
        public string A { get; set; }
        public string B { get; set; }

        [ForeignKey(nameof(Device))]
        public int DeviceId { get; set; }
        public Device Device { get; set; }
    }
}
