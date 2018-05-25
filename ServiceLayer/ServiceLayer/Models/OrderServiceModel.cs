using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DataAccessLayer.Models;

namespace ServiceLayer.Models
{
    public class OrderServiceModel
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

    public class OrderServiceMapper : Profile
    {
        public OrderServiceMapper()
        {
            CreateMap<Order, OrderServiceModel>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.OrderID, y => y.Ignore())
                .ForSourceMember(x => x.PaymentID, y => y.Ignore())
                .ForSourceMember(x => x.AddressID, y => y.Ignore())
                .ForSourceMember(x => x.Status, y => y.Ignore());
                //.ForSourceMember(x => x.OrderCoupons, y => y.Ignore())
                //.ForSourceMember(x => x.OrderCoupons1, y => y.Ignore())
                //.ForSourceMember(x => x.OrderItems, y => y.Ignore());

            CreateMap<OrderServiceModel, Order>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.OrderID, y => y.Ignore())
                .ForSourceMember(x => x.PaymentID, y => y.Ignore())
                .ForSourceMember(x => x.AddressID, y => y.Ignore())
                .ForSourceMember(x => x.Status, y => y.Ignore());
            //.ForSourceMember(x => x.OrderCoupons, y => y.Ignore())
            //.ForSourceMember(x => x.OrderCoupons1, y => y.Ignore())
            //.ForSourceMember(x => x.OrderItems, y => y.Ignore());

        }
    }
}