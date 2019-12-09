using Microsoft.AspNetCore.Identity;
using System;

namespace CoreAutomotive.Models
{
    public class UserData : IdentityUser<int>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime DateJoined { get; set; }


    }
}
