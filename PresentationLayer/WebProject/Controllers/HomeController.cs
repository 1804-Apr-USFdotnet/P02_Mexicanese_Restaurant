using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class HomeController : AServiceController
    {
        public async Task<ActionResult> Index()
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/data");

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
                if (apiResponse.StatusCode != HttpStatusCode.Unauthorized)
                {
                    return View("Error");
                }
                ViewBag.Message = "Not logged in!";
            }
            else
            {
                var contentString = await apiResponse.Content.ReadAsStringAsync();
                ViewBag.Message = "Logged in! Result: " + contentString;
            }

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}