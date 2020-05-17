using ALoRa.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Repos
{
    public class ApplicatieRepo : IApplicatieRepo
    {
        private TTNdbContext context;

        public ApplicatieRepo(TTNdbContext context)
        {
            this.context = context;
        }

        public void Add(Applicatie applicatie)
        {
            context.Applicaties.Add(applicatie);
            context.SaveChanges();
        }

        public void Delete(Applicatie applicatie)
        {
            context.Applicaties.Remove(applicatie);
            context.SaveChanges();
        }

        public IList<Applicatie> GetAll()
        {
            return context.Applicaties.ToList();
        }

        public Applicatie GetOne(string name)
        {
            return context.Applicaties.Where(a => a.AppName == name).SingleOrDefault();
        }

        public void Update(Applicatie applicatie)
        {
            context.SaveChanges();
        }
    }
}
