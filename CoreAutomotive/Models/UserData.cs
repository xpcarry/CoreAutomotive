using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Models
{
    public class UserData : IdentityUser<int>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime DateJoined { get; set; }
        public ICollection<Samochod> Cars { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }

    }
}
