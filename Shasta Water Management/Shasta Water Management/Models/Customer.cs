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
        public string CustomerID { get; set; }

        [StringLength(32)]
        public string Name { get; set; }

        [StringLength(15)]
        public string CellPhoneNum { get; set; }

        [StringLength(15)]
        public string HomePhoneNum { get; set; }

        [StringLength(50)]
        public string Address { get; set; }

        [StringLength(2147483647)]
        public string City { get; set; }

        [StringLength(2147483647)]
        public string Zip { get; set; }

        public bool? Owner { get; set; }

        public int? CustEquipID { get; set; }

        [StringLength(500)]
        public string Notes { get; set; }

        public virtual CustEquip CustEquip { get; set; }
    }
}
