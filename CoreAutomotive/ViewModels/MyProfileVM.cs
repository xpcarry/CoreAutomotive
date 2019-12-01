using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class MyProfileVM
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime DateJoined { get; set; }
        public IEnumerable<Car> MyCars { get; set; }
        public List<Picture> Pictures { get; set; }

    }
}
