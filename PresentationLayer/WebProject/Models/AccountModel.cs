using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class AccountModel
    {

        [Key]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(255)]
        public string Pwd { get; set; }

        public int AccessLevel { get; set; }

        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        // public virtual ICollection<Address> Addresses { get; set; }

        //public virtual CustomerInformation CustomerInformation { get; set; }
    }
    public class AccountModelMapper : Profile
    {
        public AccountModelMapper()
        {
            CreateMap<User, AccountModel>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.Pwd, y => y.Ignore())
                .ForSourceMember(x => x.AccessLevel, y => y.Ignore());
            //.ForSourceMember(x => x.itemPrice, y => y.Ignore())
            //.ForSourceMember(x => x.Stock, y => y.Ignore())

            CreateMap<AccountModel, User>()
                .ForSourceMember(x => x.Email, y => y.Ignore())
                .ForSourceMember(x => x.Pwd, y => y.Ignore())
                .ForSourceMember(x => x.AccessLevel, y => y.Ignore());
            //.ForSourceMember(x => x.itemPrice, y => y.Ignore())
            //.ForSourceMember(x => x.Stock, y => y.Ignore())
        }
    }
}