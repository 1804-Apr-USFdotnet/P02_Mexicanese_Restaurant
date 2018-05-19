using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DataAccessLayer.Models;

namespace ServiceLayer.Models
{
    public class MenuItemServiceModel
    {
        public int itemID;

        [Required]
        [StringLength(255)]
        public string itemName { get; set; }

        [Required]
        [StringLength(1024)]
        public string itemDescription { get; set; }

        [Required]
        public decimal itemPrice { get; set; }

        [Required]
        public int Stock { get; set; }

        //May need to add ICollection<OrderItemServiceModel> later to satisfy mapping
        //public virtual ICollection<OrderItem> OrderItems { get; set; }
    }

    public class MenuItemServiceMapper : Profile
    {
        public MenuItemServiceMapper()
        {
            CreateMap<MenuItem, MenuItemServiceModel>()
                .ForSourceMember(x => x.itemID, y => y.Ignore())
                .ForSourceMember(x => x.itemName, y => y.Ignore())
                .ForSourceMember(x => x.itemDescription, y => y.Ignore())
                .ForSourceMember(x => x.itemPrice, y => y.Ignore())
                .ForSourceMember(x => x.Stock, y => y.Ignore());

            CreateMap<MenuItemServiceModel, MenuItem> ()
                .ForSourceMember(x => x.itemID, y => y.Ignore())
                .ForSourceMember(x => x.itemName, y => y.Ignore())
                .ForSourceMember(x => x.itemDescription, y => y.Ignore())
                .ForSourceMember(x => x.itemPrice, y => y.Ignore())
                .ForSourceMember(x => x.Stock, y => y.Ignore());
        }

    }
}