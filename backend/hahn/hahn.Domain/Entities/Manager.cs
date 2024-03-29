﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hahn.Domain.Entities
{
    public class Manager : ApplicationUser
    {
        public DateTime Created { get; set; }
        public string street { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string zipcode { get; set; }
        public string country { get; set; }
        public List<Product>? Products { get; set; }
    }
}
