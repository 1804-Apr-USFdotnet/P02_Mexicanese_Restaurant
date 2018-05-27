namespace DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Coupon
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Coupon()
        {
            OrderCoupons = new HashSet<OrderCoupon>();
        }

        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string couponCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime expDate { get; set; }

        public decimal discountAmount { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; }
    }
}
