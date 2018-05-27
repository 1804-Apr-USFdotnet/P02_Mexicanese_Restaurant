using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebProject.Models
{
    public class OrderCoupon
    {
        public int couponId { get; set; }


        public int orderID { get; set; }


        public virtual Coupon Coupon { get; set; }

        public virtual Order Order { get; set; }

        public virtual Order Order1 { get; set; }
    }
}