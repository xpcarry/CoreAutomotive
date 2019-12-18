using CoreAutomotive.Models;
using System;
using System.Collections.Generic;

namespace CoreAutomotive.ViewModels
{
    public class ViewProfile
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime DateJoined { get; set; }
        public ICollection<Car> UserCars { get; set; }
        public List<Picture> UserPictures { get; set; }
        public int CarsAmount { get; set; }
        public string City { get; set; }

    }
}
