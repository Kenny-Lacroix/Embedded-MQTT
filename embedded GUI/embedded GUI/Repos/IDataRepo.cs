using embedded_GUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace embedded_GUI.Repos
{
    public interface IDataRepo
    {
        void Add(Data data);
        void Update(Data data);
        Data GetOne(DateTime time);
        IList<Data> GetAll();
        void Delete(Data data);
    }
}
