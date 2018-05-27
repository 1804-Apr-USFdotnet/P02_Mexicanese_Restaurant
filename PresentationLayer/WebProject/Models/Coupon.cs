using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ServiceLayer.Models
{
    public class Coupon
    {
        public int id { get; set; }

        [Required]
        [StringLength(255)]
        public string couponCode { get; set; }

        [Column(TypeName = "date")]
        public DateTime expDate { get; set; }

        [Required]
        [Range(0.1,0.5)] 
        public decimal discountAmount { get; set; }
        
        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; }
        
    }
}