using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace CoreAutomotive.Models
{
    public class UserData : IdentityUser<int>
    {

        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public DateTime DateJoined { get; set; }

        [Display(Name="Phone Number")]
        public override string PhoneNumber { get => base.PhoneNumber; set => base.PhoneNumber = value; }

    }
}
