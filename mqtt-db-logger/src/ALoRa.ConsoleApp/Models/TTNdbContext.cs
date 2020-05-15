using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Models
{
    public class TTNdbContext : DbContext
    {

        protected TTNdbContext() : base("datasource=127.0.0.1;port=3306;username=root;password=;database=lora;")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TTNdbContext>());
        }

        public DbSet<Applicatie> Applicaties { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Device> Devices { get; set; }


    }
}
