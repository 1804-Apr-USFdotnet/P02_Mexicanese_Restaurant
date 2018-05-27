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
    public class OrderItemServiceModel
    {
        
        public int itemID { get; set; }

       
        public int orderID { get; set; }

        public int quantity { get; set; }

        public virtual MenuItem MenuItem { get; set; }

        public virtual Order Order { get; set; }
    }

    public class OrderItemServiceMapper : Profile
    {
        public OrderItemServiceMapper()
        {
            CreateMap<OrderItem, OrderItemServiceModel>()
                .ForSourceMember(x => x.itemID, y => y.Ignore())
                .ForSourceMember(x => x.orderID, y => y.Ignore())
                .ForSourceMember(x => x.MenuItem, y => y.Ignore())
                .ForSourceMember(x => x.Order, y => y.Ignore());

            CreateMap<OrderItem, OrderItemServiceModel>()
                .ForSourceMember(x => x.itemID, y => y.Ignore())
                .ForSourceMember(x => x.orderID, y => y.Ignore())
                .ForSourceMember(x => x.MenuItem, y => y.Ignore())
                .ForSourceMember(x => x.Order, y => y.Ignore());

        }

    }
}
