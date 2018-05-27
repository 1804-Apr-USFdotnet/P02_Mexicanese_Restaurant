using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class MenuItemController : AServiceController
    {
        //private static readonly HttpClient httpClient = new HttpClient();

        // GET: MenuItem
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            //httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            HttpResponseMessage response = await HttpClient.GetAsync(
                "http://localhost:49971/api/menuitem/");

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
        public ActionResult CreateAsync()
        {
            return View();
        }

        // POST: MenuItem/Create
        [HttpPost]
        public async Task<ActionResult> CreateAsync(MenuItem collection)//change forcollection to the actual model
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View("Error");
                }
                // TODO: Add insert logic here
                var content = new StringContent(JsonConvert.SerializeObject(collection));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage request = await HttpClient.PostAsync(
                    "http://localhost:49971/api/menuitem/", content);

                if (!request.IsSuccessStatusCode)
                {
                    return View("Error");
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItem/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MenuItem/Edit/5
        [HttpPost]
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
                var content = new StringContent(JsonConvert.SerializeObject(collection));
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                HttpResponseMessage request = await HttpClient.PutAsync(
                    "http://localhost:49971/api/menuitem/" + id, content);

                if (!request.IsSuccessStatusCode)
                {

                    return View("Error" + request.StatusCode);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: MenuItem/Delete/5
        public ActionResult DeleteAsync(int id)
        {
            return View();
        }

        // POST: MenuItem/Delete/5
        [HttpPost]
        public async Task<ActionResult> DeleteAsync(int id, MenuItem collection)
        {
            try
            {
                HttpResponseMessage remove = await HttpClient.DeleteAsync(
                    "http://localhost:49971/api/menuitem/" + id);
                if (!remove.IsSuccessStatusCode)
                {

                    return View("Error" + remove.StatusCode);
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}