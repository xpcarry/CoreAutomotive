﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreAutomotive.Models
{
    public class Samochod
    {
        public int Id { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public int RokProdukcji { get; set; }
        public string Przebieg { get; set; }
        public string Pojemnosc { get; set; }
        public string RodzajPaliwa { get; set; }
        public string Moc { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }
        public string ZdjecieUrl { get; set; }
        public string MiniaturkaUrl { get; set; }
        public bool JestSamochodemTygodnia { get; set; }
        public bool JestWCentrali { get; set; }
        public bool Approved { get; set; }
    }
}
