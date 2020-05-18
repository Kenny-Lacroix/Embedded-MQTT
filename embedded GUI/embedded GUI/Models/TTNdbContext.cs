using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embedded_GUI.Models
{
    public class TTNdbContext : DbContext
    {

        public TTNdbContext() : base(@"data source=(LocalDB)\MSSQLLocalDB;initial catalog=TTN;integrated security=True")
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<TTNdbContext>());
        }

        public DbSet<Applicatie> Applicaties { get; set; }
        public DbSet<Data> Datas { get; set; }
        public DbSet<Device> Devices { get; set; }


    }
}
