using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using DataAccessLayer.Models;

namespace ServiceLayer.Models
{
    public class PaymentMethodServiceModel
    {
        public int id { get; set; }

        public string email { get; set; }

        public string cardNumber { get; set; }

        public string securityCode { get; set; }

        public DateTime expDate { get; set; }
    }

    public class PaymentMethodServiceMapper : Profile
    {
        public PaymentMethodServiceMapper()
        {
            CreateMap<PaymentMethod, PaymentMethodServiceModel>()
                .ForSourceMember(x => x.id, y => y.Ignore())
                .ForSourceMember(x => x.email, y => y.Ignore())
                .ForSourceMember(x => x.cardNumber, y => y.Ignore())
                .ForSourceMember(x => x.securityCode, y => y.Ignore())
                .ForSourceMember(x => x.expDate, y => y.Ignore());

            CreateMap<PaymentMethodServiceModel, PaymentMethod>()
                .ForSourceMember(x => x.id, y => y.Ignore())
                .ForSourceMember(x => x.email, y => y.Ignore())
                .ForSourceMember(x => x.cardNumber, y => y.Ignore())
                .ForSourceMember(x => x.securityCode, y => y.Ignore())
                .ForSourceMember(x => x.expDate, y => y.Ignore());

        }
    }
}