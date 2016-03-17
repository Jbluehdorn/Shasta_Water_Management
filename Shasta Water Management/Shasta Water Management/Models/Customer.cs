using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shasta_Water_Management.Models
{
    public class Customer
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public IEnumerable<Equipment> Equipment { get; set; }
        public DateTime LastServiceDate { get; set; }
        public int ServiceInterval { get; set; }
        public string Notes { get; set; }
        public string Address { get; set; }
    }
}