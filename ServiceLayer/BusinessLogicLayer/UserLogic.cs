using DataAccessLayer.Models;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System;

namespace BusinessLogicLayer
{
    public class UserLogic : IUser
    {
        private readonly IUserRepository _UsrRepo;
        public UserLogic(IUserRepository UsrRepo)
        {
            _UsrRepo = UsrRepo;
        }
        public void AddUsr(User Usr)
        {
            _UsrRepo.AddUser(Usr);
        }

        public List<User> AllUsr()
        {
            return _UsrRepo.GetAllUsers().ToList();
        }

        public void DeleteUsr(User Usr)
        {
            _UsrRepo.DeleteUser(Usr);
        }

        public User GetUserByEmail(String email)
        {
            return _UsrRepo.GetByEmail(email);
        }

        public void UpdateUsr(User Usr)
        {
            _UsrRepo.ModifyUser(Usr);
        }
    }
}