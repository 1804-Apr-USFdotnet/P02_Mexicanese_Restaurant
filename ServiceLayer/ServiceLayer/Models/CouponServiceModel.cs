using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web.Http;
using AutoMapper;


namespace ServiceLayer.Models
{
    public class CouponServiceModel
    {
        //public CouponServiceModel()
        //{
        //    OrderCoupons = new HashSet<OrderCoupon>();
        //}

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
        public class OrderServiceMapper : Profile
        {
            public OrderServiceMapper()
            {
                CreateMap<Coupon, CouponServiceModel>()
                    .ForSourceMember(x => x.id, y => y.Ignore())
                    .ForSourceMember(x => x.couponCode, y => y.Ignore())
                    .ForSourceMember(x => x.expDate, y => y.Ignore())
                    .ForSourceMember(x => x.discountAmount, y => y.Ignore())
                    .ForSourceMember(x => x.OrderCoupons, y => y.Ignore());

                CreateMap<CouponServiceModel, Coupon>()
                      .ForSourceMember(x => x.id, y => y.Ignore())
                    .ForSourceMember(x => x.couponCode, y => y.Ignore())
                    .ForSourceMember(x => x.expDate, y => y.Ignore())
                    .ForSourceMember(x => x.discountAmount, y => y.Ignore())
                    .ForSourceMember(x => x.OrderCoupons, y => y.Ignore());

            }
        }
    }
}