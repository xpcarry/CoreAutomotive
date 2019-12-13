using System;
using System.Collections.Generic;

namespace CoreAutomotive.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Mileage { get; set; }
        public string Engine { get; set; }
        public string FuelType { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<Picture> Pictures { get; set; } = null;
        public DateTime DateAdded { get; set; }
        public bool Featured { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }
    }
}
