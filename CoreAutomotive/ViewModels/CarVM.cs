using CoreAutomotive.Models;
using System.Collections.Generic;

namespace CoreAutomotive.ViewModels
{
    public class CarVM
    {
        public Car Car { get; set; }
        public List<Picture> Pictures { get; set; }
        public string ActionCode { get; set; } = "0";
    }
}
