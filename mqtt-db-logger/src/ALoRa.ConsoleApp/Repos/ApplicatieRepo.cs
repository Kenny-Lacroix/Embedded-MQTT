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
            Console.WriteLine("Application test");
            context.SaveChanges();

        }

        public void Update(Applicatie applicatie)
        {
            context.SaveChanges();
        }
    }
}
