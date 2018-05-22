using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AutoMapper;
using DataAccessLayer.Models;

namespace ServiceLayer.Models
{
    public class AddressServiceModel
    {
        public int id { get; set; }

        [Required] [StringLength(255)]
        public string email { get; set; }

        [Column("address")]
        [Required]
        [StringLength(255)]
        public string address1 { get; set; }

        [Required]
        [StringLength(255)]
        public string city { get; set; }

        [Required]
        [StringLength(100)]
        public string state { get; set; }

        [Required]
        [StringLength(20)]
        public string zipcode { get; set; }

        public virtual User User { get; set; }
    }
    public class AddressServiceMapper : Profile
    {
        public AddressServiceMapper()
        {
            CreateMap<Address, AddressServiceModel>()
                .ForSourceMember(x => x.id, y => y.Ignore())
                .ForSourceMember(x => x.email, y => y.Ignore())
                .ForSourceMember(x => x.address1, y => y.Ignore())
                .ForSourceMember(x => x.city, y => y.Ignore())
                .ForSourceMember(x => x.state, y => y.Ignore())
                .ForSourceMember(x => x.User, y => y.Ignore());


            CreateMap<AddressServiceModel, Address>()
                .ForSourceMember(x => x.id, y => y.Ignore())
                .ForSourceMember(x => x.email, y => y.Ignore())
                .ForSourceMember(x => x.address1, y => y.Ignore())
                .ForSourceMember(x => x.city, y => y.Ignore())
                .ForSourceMember(x => x.state, y => y.Ignore())
                .ForSourceMember(x => x.User, y => y.Ignore());

        }
    }
}