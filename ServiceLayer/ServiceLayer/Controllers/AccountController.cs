using ServiceLayer.Models;
using DataAccessLayer.Models;
using BusinessLogicLayer;
using BusinessLogicLayer.models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using Owin;
using Microsoft.Owin.Security;
using NLog;
using System.Security.Claims;
using AutoMapper;

namespace ServiceLayer.Controllers
{
    public class AccountController : ApiController { 

        private readonly ILogic _identityLogic;
        private readonly IMapper _mapper;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AccountController(ILogic IdentityLogic, IMapper mapper)
        {
            _identityLogic = IdentityLogic;
            _mapper = mapper;
        }

        [HttpPost]
        //[Route("~api/Account/Register")]
        [AllowAnonymous]
        public IHttpActionResult Register(AccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var IL = _mapper.Map<LogicIdentityModel>(account);
            try
            {
                _identityLogic.Register(IL);
            }
            catch
            {
                return BadRequest();
            }

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

            var userStore = new UserStore<IdentityUser>(new IdentityDbContext<IdentityUser>("MexicaneseModel")); //is this bad? register uses it just fine
            var userManager = new UserManager<IdentityUser>(userStore); //is this bad? register uses it just fine
            var user = userManager.Users.FirstOrDefault(u => u.UserName == account.UserName); //always tests as null? why?


            if (user == null)
            {
                return NotFound(); //failing here
                
            }

            if (!userManager.CheckPassword(user, account.Password))
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