namespace Shasta_Water_Management
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Customer")]
    public partial class Customer
    {
        public int CustomerID { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(15)]
        public string CellPhoneNum { get; set; }

        [StringLength(15)]
        public string HomePhoneNum { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(10)]
        public string State { get; set; }

        [StringLength(10)]
        public string Zip { get; set; }

        [StringLength(5)]
        public string RentOwn { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public IEnumerable<CustEquip> CustEquip { get; set; }

        public IEnumerable<Equipment> Equipment { get; set; }

        public DateTime? LastService { get; set; }

        public int ServiceInterval { get; set; }

        public string Deleted { get; set; }
    }
}
