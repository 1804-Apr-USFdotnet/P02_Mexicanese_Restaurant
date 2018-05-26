using System.ComponentModel.DataAnnotations;
//using AutoMapper;
//using BusinessLogicLayer.models;

namespace WebProject.Models
{
    public class AccountModel
    {
        [Key]
        [StringLength(255)]
        public string UserName { get; set; }

        [Required]
        [StringLength(255)]
        public string Password { get; set; }

    }
    /*public class AccountModelMapper : Profile
    {
        public AccountModelMapper()
        {
            CreateMap<LogicIdentityModel, AccountModel>()
                .ForSourceMember(x => x.UserName, y => y.Ignore())
                .ForSourceMember(x => x.Password, y => y.Ignore());

            CreateMap<AccountModel, LogicIdentityModel>()
                .ForSourceMember(x => x.UserName, y => y.Ignore())
                .ForSourceMember(x => x.Password, y => y.Ignore());
        }
    }
    */
}