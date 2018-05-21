using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace BusinessLogicLayer
{
    public interface IUser
    {   
        List<User> AllUsr();
        User GetUserByEmail(String email);
        void AddUsr(User Usr);
        void UpdateUsr(User Usr);
        void DeleteUsr(User Usr);
    }
}