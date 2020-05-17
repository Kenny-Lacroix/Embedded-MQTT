using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embedded_GUI.Models
{
    public class Applicatie
    {
        [Key]
        public int AppId { get; set; }

        public string AppName { get; set; }


        public ICollection<Device> Devices { get; set; }
    }
}
