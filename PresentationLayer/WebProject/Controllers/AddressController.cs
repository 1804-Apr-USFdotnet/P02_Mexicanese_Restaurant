using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Newtonsoft.Json;
using WebProject.Models;
namespace WebProject.Controllers
{
    public class AddressController : AServiceController
    {
        // GET: Address
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Address/");
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var addresss = await response.Content.ReadAsAsync<IEnumerable<Address>>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }
            return View(addresss);
        }

        // GET: Address/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Address/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var address = await response.Content.ReadAsAsync<Address>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }
            return View(address);
        }

        // GET: Address/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Address/Create
        [HttpPost]
        public async Task<ActionResult> Create(Address address)
        {
            try
            {
                // TODO: Add insert logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/address/");
                apiRequest.Content = new ObjectContent<Address>(address, new JsonMediaTypeFormatter());
                HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Address/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Address/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var address = await response.Content.ReadAsAsync<Address>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }
            return View(address);
        }

        // POST: Address/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Address address)
        {
            try
            {
                // TODO: Add update logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/Address/");
                apiRequest.Content = new ObjectContent<Address>(address, new JsonMediaTypeFormatter());
                HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View("Error");
                }
            }
            catch
            {
                return View("Error");
            }
        }

        // GET: Address/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Address/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var address = await response.Content.ReadAsAsync<Address>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }
            return View(address);
        }

        // POST: Address/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Address address)
        {
            try
            {
                // TODO: Add delete logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, "api/Address/" + address.id);
                HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
                //var result = await response.Content.ReadAsAsync<Address>();
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("List");
                }
                else
                {
                    return View("Error");
                }

            }
            catch
            {
                return View("Error");
            }
        }
    }
}
