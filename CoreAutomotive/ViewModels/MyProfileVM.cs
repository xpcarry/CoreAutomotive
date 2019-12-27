using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class MyProfileVM
    {

        public UserData User {get; set;}
        public int CarAmount { get; set; }
        public DateTime DateJoined { get; set; }
        public IEnumerable<Car> MyCars { get; set; }
        public List<Picture> Pictures { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "New Password", Description = "Put your new password here")]
        public string NewPassword { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Confirm New Password", Description = "Confirm your password")]
        public string NewPasswordConfirm { get; set; }

    }
}
