using CoreAutomotive.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.ViewModels
{
    public class CarDetailsVM
    {
        public Car Car { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }

        [StringLength(maximumLength: 300, MinimumLength = 15, ErrorMessage = "Your message must have 15-300 characters")]
        public string Message { get; set; }
        public string toUser { get; set; }
    }
}
