using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using DataAccessLayer.Models;
namespace ServiceLayer.Models
{
    public class CustomerInformationServiceModel
    {
        [Required]
        [StringLength(255)]
        public string Email { get; set; }

        [StringLength(100)]
        public string firstName { get; set; }

        [StringLength(100)]
        public string lastName { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        public virtual User User { get; set; }
    }

    public class CustomerInformationServiceMapper : Profile
    {
        public CustomerInformationServiceMapper()
        {
            CreateMap<CustomerInformation, CustomerInformationServiceModel>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.firstName, y => y.Ignore())
                .ForSourceMember(x => x.lastName, y => y.Ignore())
                .ForSourceMember(x => x.phone, y => y.Ignore())
                .ForSourceMember(x => x.User, y => y.Ignore());


            CreateMap<CustomerInformationServiceModel, CustomerInformation>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.firstName, y => y.Ignore())
                .ForSourceMember(x => x.lastName, y => y.Ignore())
                .ForSourceMember(x => x.phone, y => y.Ignore())
                .ForSourceMember(x => x.User, y => y.Ignore());

        }

    }
}