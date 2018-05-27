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
    public class MenuItemController : AServiceController
    {
        private static readonly HttpClient httpClient = new HttpClient();

        // GET: MenuItem
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/menuitem/");
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            //HttpResponseMessage response = await httpClient.GetAsync("http://ec2-18-188-24-56.us-east-2.compute.amazonaws.com/mexicaneserestaurant/api/menuitem");

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var menuitem = await response.Content.ReadAsAsync<IEnumerable<MenuItem>>();
            return View(menuitem);
        }



        // GET: MenuItem/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/menuitem/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }

            var menuitem = await response.Content.ReadAsAsync<MenuItem>();
            return View(menuitem);
        }

        // GET: MenuItem/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuItem/Create
        [HttpPost]
        public async Task<ActionResult> Create(MenuItem collection)//change forcollection to the actual model
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }
                // TODO: Add insert logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/menuitem");
                apiRequest.Content = new ObjectContent<MenuItem>(collection, new JsonMediaTypeFormatter());

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
                return RedirectToAction("Index", "MenuItem");
            }
            catch
            {
                return View();
            }

        }

        // GET: MenuItem/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/menuitem/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }

            var menuitem = await response.Content.ReadAsAsync<MenuItem>();
            return View(menuitem);
        }

        // PUT: MenuItem/Edit/5
        [HttpPut]
        public async Task<ActionResult> Edit(int id, MenuItem collection)
        {
            try
            {
                // TODO: Add update logic here
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }
                collection.itemID = id;
                // TODO: Add insert logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/menuitem/"+collection.itemID);
                apiRequest.Content = new ObjectContent<MenuItem>(collection, new JsonMediaTypeFormatter());

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
                    //HttpResponseMessage request = await httpClient.PutAsync("http://ec2-18-188-24-56.us-east-2.compute.amazonaws.com/mexicaneserestaurant/api/menuitem/" +id, content);
                    return View("Error" + apiResponse.StatusCode);
                }
                return RedirectToAction("Index", "MenuItem");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItem/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/menuitem/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            if (!response.IsSuccessStatusCode)
            {

                return View("Error" + response.StatusCode);
            }

            var menuitem = await response.Content.ReadAsAsync<MenuItem>();
            return View(menuitem);
        }

        // POST: MenuItem/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, MenuItem collection)
        {
            try
            {
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, "api/menuitem/" + id);
                //HttpResponseMessage remove = await httpClient.DeleteAsync("http://ec2-18-188-24-56.us-east-2.compute.amazonaws.com/mexicaneserestaurant/api/menuitem/" + id);
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
                return RedirectToAction("Index", "MenuItem");
            }
            catch
            {
                return View();
            }
        }
    }
}

