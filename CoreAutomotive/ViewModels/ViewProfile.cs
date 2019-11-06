using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class ViewProfile
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public ICollection<Car> UserCars { get; set; }

    }
}
