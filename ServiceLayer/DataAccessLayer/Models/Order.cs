namespace DataAccessLayer.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Order
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Order()
        {
            OrderCoupons = new HashSet<OrderCoupon>();
            OrderCoupons1 = new HashSet<OrderCoupon>();
            OrderItems = new HashSet<OrderItem>();
        }

        public int OrderID { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public int PaymentID { get; set; }

        public int AddressID { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderCoupon> OrderCoupons1 { get; set; }
        //[Required]
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
