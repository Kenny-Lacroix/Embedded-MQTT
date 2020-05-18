using embedded_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embedded_GUI.Repos
{
    public interface IApplicatieRepo
    {
        void Add(Applicatie applicatie);
        void Update(Applicatie applicatie);
        Applicatie GetOne(int id);
        IList<Applicatie> GetAll();
        void Delete(Applicatie applicatie);
    }
}
