using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class HomeVM
    {
        public string Tytul { get; set; }
        public List<Samochod> Samochody { get; set; }

    }
}
