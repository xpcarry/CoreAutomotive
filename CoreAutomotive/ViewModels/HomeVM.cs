﻿using CoreAutomotive.Models;
using System;
using System.Collections.Generic;

namespace CoreAutomotive.ViewModels
{
    public class HomeVM
    {

        public string Tytul { get; set; }
        public List<Car> Cars { get; set; }
        public string UserName { get; set; }
        public DateTime DateAdded { get; set; }
        public List<Picture> Pictures { get; set; }

    }
}
