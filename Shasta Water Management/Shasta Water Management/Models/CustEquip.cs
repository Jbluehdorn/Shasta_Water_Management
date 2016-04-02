namespace Shasta_Water_Management
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CustEquip")]
    public partial class CustEquip
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public CustEquip()
        {
            Customers = new HashSet<Customer>();
        }

        public int CustEquipID { get; set; }

        [StringLength(50)]
        public string SerialNum { get; set; }

        public int EquipID { get; set; }

        public int ServiceInterval { get; set; }

        public virtual Equipment Equipment { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
