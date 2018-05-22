using ServiceLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace ServiceLayer.Controllers
{
    public class AccountController : ApiController
    {
        
        [HttpPost]
        //[Route]
        [AllowAnonymous]
        public IHttpActionResult Register(AccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userStore = new UserStore<IdentityUser>(new IdentityDbContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(account.Email);

            if (userManager.Users.Any(u => u.UserName == account.Email))
            {
                return BadRequest();
            }

            userManager.Create(user, account.Pwd);

            return Ok();
        }

        [HttpPost]
        [Route("~/api/Account/Login")]
        [AllowAnonymous]
        public IHttpActionResult LogIn(AccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            // actually login
            var userStore = new UserStore<IdentityUser>(new IdentityDbContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = userManager.Users.FirstOrDefault(u => u.UserName == account.Email);

            if (user == null)
            {
                return BadRequest();
            }

            if (!userManager.CheckPassword(user, account.Pwd))
            {
                return Unauthorized();
            }

            var authManager = Request.GetOwinContext().Authentication;
            var claimsIdentity = userManager.CreateIdentity(user, WebApiConfig.AuthenticationType);

            authManager.SignIn(new AuthenticationProperties { IsPersistent = true }, claimsIdentity);

            return Ok();
        }
    }
}