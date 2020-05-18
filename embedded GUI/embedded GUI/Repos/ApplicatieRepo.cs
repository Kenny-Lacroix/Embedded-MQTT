using embedded_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embedded_GUI.Repos
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

        public Applicatie GetOne(int id)
        {
            return context.Applicaties.Where(a => a.AppId == id).SingleOrDefault();
        }

        public void Update(Applicatie applicatie)
        {
            context.SaveChanges();
        }
    }
}
