using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shasta_Water_Management.Models
{
    public class Equipment
    {
        public string ID { get; set; }
        public string Type { get; set; }
        public string Serial { get; set; }
        public string ModelNum { get; set; }
        public int Diagnostics { get; set; }
    }
}