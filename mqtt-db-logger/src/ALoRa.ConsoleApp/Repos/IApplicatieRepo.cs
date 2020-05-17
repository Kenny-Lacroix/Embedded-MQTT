using ALoRa.ConsoleApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ALoRa.ConsoleApp.Repos
{
    public interface IApplicatieRepo
    {
        void Add(Applicatie applicatie);
        void Update(Applicatie applicatie);
    }
}
