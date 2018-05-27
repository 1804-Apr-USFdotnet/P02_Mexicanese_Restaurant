using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ServiceLayer.Models
{
    public class Order
    {

        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        public int OrderID { get; set; }

        public int PaymentID { get; set; }

        public int AddressID { get; set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }


        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; }

        public virtual ICollection<OrderCoupon> OrderCoupons1 { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

}