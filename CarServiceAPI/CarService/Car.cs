using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarServiceAPI
{
    public class Car
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public int ProductionYear { get; set; }
        public string Mileage { get; set; }
        public string Engine { get; set; }
        public string FuelType { get; set; }
        public string Power { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
