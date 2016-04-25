namespace Shasta_Water_Management
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    //using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using SQLite;
    [Table("CustEquip")]
    public partial class CustEquip 
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustEquip()
        {
            Customers = new HashSet<Customer>();
        }

        [AutoIncrement]
        public int CustEquipID { get; set; }

        public int CustomerID { get; set; }

        [StringLength(32)]
        public string Type { get; set; }

        [StringLength(50)]
        public string ModelNum { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(50)]
        public string SerialNum { get; set; }

        [StringLength(5)]
        public string RentOwn { get; set; }

        [StringLength(500)]
        public string Diagnostics { get; set; }

        [StringLength(1)]
        public string Deleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
