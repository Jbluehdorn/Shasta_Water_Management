namespace Shasta_Water_Management
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Service
    {
        [Key]
        public int TripID { get; set; }

        public int CustomerID { get; set; }

        [StringLength(2147483647)]
        public string StartLoc { get; set; }

        [StringLength(2147483647)]
        public string EndLoc { get; set; }

        [Column(TypeName = "real")]
        public double? Distance { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(500)]
        public string Diagnostics { get; set; }
    }
}
