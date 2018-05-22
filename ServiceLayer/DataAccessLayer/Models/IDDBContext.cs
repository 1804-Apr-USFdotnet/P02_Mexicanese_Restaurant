using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DataAccessLayer.Models
{
    public class IDDBContext : IdentityDbContext<IdentityUser>
    {
        public IDDBContext() : base("name=MexicaneseModel")
        {
        }
    }
}
