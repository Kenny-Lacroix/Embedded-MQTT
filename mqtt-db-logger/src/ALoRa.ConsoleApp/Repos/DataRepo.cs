using ALoRa.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Repos
{
    public class DataRepo : IDataRepo
    {
        private TTNdbContext context;

        public DataRepo(TTNdbContext context)
        {
            this.context = context;
        }

        public void Add(Data data)
        {
            context.Datas.Add(data);
            context.SaveChanges();
            Console.WriteLine("Data added");
        }

        public void Update(Data data)
        {
            context.SaveChanges();
        }
    }
}
