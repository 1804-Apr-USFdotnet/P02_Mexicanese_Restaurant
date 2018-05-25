using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DataAccessLayer.Models;

namespace ServiceLayer.Models
{
    public class UserServiceModel
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Pwd { get; set; }


        public int AccessLevel { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        //public virtual ICollection<Address> Addresses { get; set; }

        public virtual CustomerInformation CustomerInformation { get; set; }
    }
    public class UserServiceMapper : Profile
    {
        public UserServiceMapper()
        {
            CreateMap<User, UserServiceModel>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.CustomerInformation, y => y.Ignore())
                //.ForSourceMember(x => x.Addresses, y => y.Ignore())
                .ForSourceMember(x => x.AccessLevel, y => y.Ignore());
                

            CreateMap<UserServiceModel, User>()
                 .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.CustomerInformation, y => y.Ignore())
                //.ForSourceMember(x => x.Addresses, y => y.Ignore())
                .ForSourceMember(x => x.AccessLevel, y => y.Ignore());
                
        }

    }
}