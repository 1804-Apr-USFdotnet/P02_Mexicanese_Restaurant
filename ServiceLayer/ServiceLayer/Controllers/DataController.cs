using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Net.Http;
using System.Web.Http;

namespace ServiceLayer.Controllers
{
    public class DataController : ApiController
    {
        public IHttpActionResult Get()
        {
            // making use of global authorize filter in webapiconfig / filterconfig

            // get the currently logged-in user
            var user = Request.GetOwinContext().Authentication.User;

            // get his username
            string username = user.Identity.Name;

            // get whether user has some role
            bool isAdmin = user.IsInRole("admin");

            // get all user's roles
            List<string> roles = user.Claims.Where(x => x.Type == ClaimTypes.Role).Select(x => x.Value.ToString()).ToList();

            return Ok($"Authenticated {username}, with roles: [{string.Join(", ", roles)}]!");
        }
    }
}
