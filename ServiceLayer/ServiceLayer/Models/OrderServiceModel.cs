using System.CodeDom;
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

        //public decimal Total => GetTotal();

        //public List<MenuItem> MenuItems { get; private set; }

        [Required]
        [StringLength(100)]
        public string Status { get; set; }


        public virtual ICollection<OrderCoupon> OrderCoupons { get; set; }
        public virtual ICollection<OrderCoupon> OrderCoupons1 { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        //public OrderServiceModel()
        //{
        //    if (OrderItems != null)
        //    {
        //        foreach (var odrI in OrderItems)
        //        {
        //            MenuItems.Add(odrI.getMenuItem());
        //        }
        //    }
        //}
        //private decimal GetTotal()
        //{
        //    decimal total = 0;
        //    //get gross total
        //    foreach (var ord in OrderItems)
        //    {
        //        total += ord.MenuItem.itemPrice;
        //    }
        //    //deduct coupons


        //    return total;
        //}

        //private List<MenuItem> GetMenuItems()
        //{
        //    List<MenuItem> list = new List<MenuItem>();
        //    foreach (var orditem in OrderItems)
        //    {
        //        list.Add(orditem.MenuItem);
        //    }

        //    return list;
        //}
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
                .ForSourceMember(x => x.Status, y => y.Ignore())
                .ForSourceMember(x => x.OrderCoupons, y => y.Ignore())
                .ForSourceMember(x => x.OrderCoupons1, y => y.Ignore())
                .ForSourceMember(x => x.OrderItems, y => y.Ignore());

            CreateMap<OrderServiceModel, Order>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.OrderID, y => y.Ignore())
                .ForSourceMember(x => x.PaymentID, y => y.Ignore())
                .ForSourceMember(x => x.AddressID, y => y.Ignore())
                .ForSourceMember(x => x.Status, y => y.Ignore())
                .ForSourceMember(x => x.OrderCoupons, y => y.Ignore())
                .ForSourceMember(x => x.OrderCoupons1, y => y.Ignore())
                .ForSourceMember(x => x.OrderItems, y => y.Ignore());


        }
    }
}