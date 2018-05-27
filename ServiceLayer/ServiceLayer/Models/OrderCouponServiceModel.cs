using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using AutoMapper;
using DataAccessLayer.Models;

namespace ServiceLayer.Models
{
    public class OrderCouponServiceModel
    {
        public int couponId { get; set; }


        public int orderID { get; set; }


        public virtual Coupon Coupon { get; set; }

        public virtual Order Order { get; set; }

        public virtual Order Order1 { get; set; }
    }

    public class OrderCouponServiceMapper : Profile
    {
        public OrderCouponServiceMapper()
        {
            CreateMap<OrderCoupon, OrderCouponServiceModel>()
                .ForSourceMember(x => x.couponId, y => y.Ignore())
                .ForSourceMember(x => x.orderId, y => y.Ignore())
                .ForSourceMember(x => x.Coupon, y => y.Ignore())
                .ForSourceMember(x => x.Order, y => y.Ignore())
                .ForSourceMember(x => x.Order1, y => y.Ignore());

            CreateMap<OrderCoupon, OrderCouponServiceModel>()
                .ForSourceMember(x => x.couponId, y => y.Ignore())
                .ForSourceMember(x => x.orderId, y => y.Ignore())
                .ForSourceMember(x => x.Coupon, y => y.Ignore())
                .ForSourceMember(x => x.Order, y => y.Ignore())
                .ForSourceMember(x => x.Order1, y => y.Ignore());

        }

    }
}