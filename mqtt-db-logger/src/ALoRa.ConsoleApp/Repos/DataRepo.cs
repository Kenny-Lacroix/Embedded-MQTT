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
        }

        public void Delete(Data data)
        {
            context.Datas.Remove(data);
            context.SaveChanges();
        }

        public IList<Data> GetAll()
        {
            return context.Datas.ToList();
        }

        public Data GetOne(DateTime time)
        {
            return context.Datas.Where(a => a.TimeStamp == time).SingleOrDefault();
        }

        public void Update(Data data)
        {
            context.SaveChanges();
        }
    }
}
