using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace DataAccessLayer
{
    public interface IUserRepository
    {
        User GetByEmail(String email);
        IEnumerable<User> GetAllUsers();
        void AddUser(User Usr);
        void ModifyUser(User Usr);
        void DeleteUser(User Usr);
        void SaveUsers();
    }
}