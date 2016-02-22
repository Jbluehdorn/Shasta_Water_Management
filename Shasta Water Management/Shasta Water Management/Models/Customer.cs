﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shasta_Water_Management.Models
{
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public IEnumerable<Equipment> Equipment { get; set; }
        public DateTime LastServiceDate { get; set; }
        public string OwnRent { get; set; }
        public string ServiceInterval { get; set; }
        public string Notes { get; set; }
    }
}