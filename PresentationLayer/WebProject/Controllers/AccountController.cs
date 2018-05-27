using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Net.Http;
using System.Net.Http.Formatting;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class AccountController : AServiceController
    {

        // GET: Account/Login
        public ActionResult Login()
        {
            return View();
        }

        //POST: Account/Login
        [HttpPost]
        public async Task<ActionResult> Login(AccountModel account)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/Account/Login");
            apiRequest.Content = new ObjectContent<AccountModel>(account, new JsonMediaTypeFormatter());

            HttpResponseMessage apiResponse;
            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch 
            {
                return View("Error");
            }

            if (PassCookiesToClient(apiResponse))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Error");
            }
        }

        //GET: Account/Logout
        public async Task<ActionResult> Logout()
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Account/Logout");
            HttpResponseMessage apiResponse;

            try
            {
                apiResponse = await HttpClient.SendAsync(apiRequest);
            }
            catch
            {
                return View("Error");
            }

            if (!apiResponse.IsSuccessStatusCode)
            {
                return View("Error");
            }

            PassCookiesToClient(apiResponse);
            return RedirectToAction("Index", "Home");
        }

        
           
    }
}