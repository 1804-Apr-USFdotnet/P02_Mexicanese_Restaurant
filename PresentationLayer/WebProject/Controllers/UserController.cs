using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebProject.Models;



namespace WebProject.Controllers
{
    public class UserController : AServiceController
    {
        private static readonly HttpClient httpClient = new HttpClient();
        // GET: User
        public async Task<ActionResult> Index()
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/User/");
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }

            var user = await response.Content.ReadAsAsync<IEnumerable<User>>();
            return View(user);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(User collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }

                CustomerInformation customerInformation = new CustomerInformation();
                customerInformation = collection.CustomerInformation;
                collection.CustomerInformation = null;
                collection.AccessLevel = 1;
                customerInformation.Email = collection.Email;

                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/User");
                apiRequest.Content = new ObjectContent<User>(collection, new JsonMediaTypeFormatter());

                HttpRequestMessage apiRequest2 = CreateRequestToService(HttpMethod.Post, "api/CustomerInformaion");
                apiRequest.Content = new ObjectContent<CustomerInformation>(customerInformation, new JsonMediaTypeFormatter());

                HttpResponseMessage apiResponse;
                try
                {
                    apiResponse = await HttpClient.SendAsync(apiRequest);
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        return View("Error" + apiResponse.StatusCode);
                    }
                }
                catch
                {
                    return View("List");
                }

                if (!apiResponse.IsSuccessStatusCode)
                {
                    return View("Error" + apiResponse.StatusCode);
                }

                try
                {
                    apiResponse = await HttpClient.SendAsync(apiRequest2);
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        return View("Error" + apiResponse.StatusCode);
                    }
                }
                catch
                {
                    return View("List");
                }

                if (!apiResponse.IsSuccessStatusCode)
                {
                    return View("Error" + apiResponse.StatusCode);
                }
                return RedirectToAction("Index", "MenuItem");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, User collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }

                CustomerInformation customerInformation = new CustomerInformation();
                customerInformation = collection.CustomerInformation;
                collection.CustomerInformation = null;
                customerInformation.Email = collection.Email;

                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/User");
                apiRequest.Content = new ObjectContent<User>(collection, new JsonMediaTypeFormatter());

                HttpRequestMessage apiRequest2 = CreateRequestToService(HttpMethod.Put, "api/CustomerInformaion");
                apiRequest.Content = new ObjectContent<CustomerInformation>(customerInformation, new JsonMediaTypeFormatter());

                HttpResponseMessage apiResponse;
                try
                {
                    apiResponse = await HttpClient.SendAsync(apiRequest);
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        return View("Error" + apiResponse.StatusCode);
                    }
                }
                catch
                {
                    return View("List");
                }

                if (!apiResponse.IsSuccessStatusCode)
                {
                    return View("Error" + apiResponse.StatusCode);
                }

                try
                {
                    apiResponse = await HttpClient.SendAsync(apiRequest2);
                    if (!apiResponse.IsSuccessStatusCode)
                    {
                        return View("Error" + apiResponse.StatusCode);
                    }
                }
                catch
                {
                    return View("List");
                }

                if (!apiResponse.IsSuccessStatusCode)
                {
                    return View("Error" + apiResponse.StatusCode);
                }
                return RedirectToAction("Index", "MenuItem");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, "api/user/" + id);
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
                    return View("Error" + apiResponse.StatusCode);
                }
                return RedirectToAction("Index", "User");
            }
            catch
            {
                return View();
            }
        }
    }
}
