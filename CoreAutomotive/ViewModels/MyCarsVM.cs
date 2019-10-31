using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class MyCarsVM
    {
        public IEnumerable<Samochod> MyCars { get; set; }
    }
}
