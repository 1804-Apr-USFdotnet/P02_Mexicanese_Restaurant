﻿using System;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using BusinessLogicLayer.models;
using System.Threading.Tasks;
using Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace BusinessLogicLayer
{
    public class identityLogic : ILogic
    {

        public void Register(LogicIdentityModel account)
        {
            var userStore = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("MexicaneseModel"));
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(account.UserName);

            var users = userManager.Users.ToList();

            userManager.Create(user, account.Password);
            userStore.Context.SaveChanges();

            //if (userManager.Users.Any(u => u.UserName == account.UserName)) { throw new Exception(); };

            
        }
    }
}