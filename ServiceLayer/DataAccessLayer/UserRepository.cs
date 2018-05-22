using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using System.Net.Http.Headers;

namespace DataAccessLayer
{
    public class UserRepository : IUserRepository
    {
        private readonly MexicaneseModel _repoContext;
        public UserRepository(MexicaneseModel context)
        {
            _repoContext = context;
        }

        public User GetByEmail(String email)
        {
            return _repoContext.Users.Find(email);
        }

        public void AddUser(User Usr)
        {
            _repoContext.Users.Add(Usr);
            _repoContext.SaveChanges();
        }

        public void DeleteUser(User Usr)
        { 
            var delete = _repoContext.Users.Find(Usr.Email);
            _repoContext.Users.Remove(delete);
            _repoContext.SaveChanges();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return _repoContext.Users;
        }

        public void ModifyUser(User Usr)
        {
            var modify = _repoContext.Users.Find(Usr.Email);
            _repoContext.Entry(modify).CurrentValues.SetValues(Usr);
            _repoContext.SaveChanges();
        }

        public void SaveUsers()
        {
            _repoContext.SaveChanges();
        }
    }
}