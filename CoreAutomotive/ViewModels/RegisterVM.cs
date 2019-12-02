using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [Display(Name="Username")]
        public string UserName { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name="Email Address")]
        public string Email { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        [Display(Name="Phone Number", ShortName ="Phone")]
        public string PhoneNumber { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Description = "Confirm your password")]
        public string ConfirmPassword { get; set; }

    }
}
