using ServiceLayer.Models;
using DataAccessLayer.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Owin;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace ServiceLayer.Controllers
{
    public class AccountController : ApiController
    {
        
        [HttpPost]
        //[Route("~api/Account/Register")]
        [AllowAnonymous]
        public IHttpActionResult Register(AccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var userStore = new UserStore<IdentityUser>(new IDDBContext());
            var userManager = new UserManager<IdentityUser>(userStore);
            var user = new IdentityUser(account.Email);

            if (userManager.Users.Any(u => u.UserName == account.Email)) //is this method just always returning null?
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
                return BadRequest(); //not failing here
            }

            // actually login
            var userStore = new UserStore<IdentityUser>(new IDDBContext()); //is this bad? register uses it just fine
            var userManager = new UserManager<IdentityUser>(userStore); //is this bad? register uses it just fine
            var user = userManager.Users.FirstOrDefault(u => u.UserName == account.Email); //always tests as null? why?

            if (user == null)
            {
                return NotFound(); //failing here
                
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

        [HttpGet]
        [Route("~/api/Account/Logout")]
        public IHttpActionResult Logout()
        {
            Request.GetOwinContext().Authentication.SignOut(WebApiConfig.AuthenticationType);
            return Ok();
        }
    }
}