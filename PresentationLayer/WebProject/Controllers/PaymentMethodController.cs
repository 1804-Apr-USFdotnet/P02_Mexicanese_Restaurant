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
    public class PaymentMethodController : AServiceController
    {
        // GET: PaymentMethod
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/PaymentMethod/");
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var payments = await response.Content.ReadAsAsync<IEnumerable<PaymentMethod>>();
            return View(payments);
        }

        // GET: PaymentMethod/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/PaymentMethod/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var payment = await response.Content.ReadAsAsync<PaymentMethod>();
            return View(payment);
        }

        // GET: PaymentMethod/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PaymentMethod/Create
        [HttpPost]
        public async Task<ActionResult> Create(PaymentMethod payment)
        {
            try
            {
                // TODO: Add insert logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/Payment/");
                apiRequest.Content = new ObjectContent<PaymentMethod>(payment, new JsonMediaTypeFormatter());
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

        // GET: PaymentMethod/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/PaymentMethod/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var payment = await response.Content.ReadAsAsync<PaymentMethod>();
            return View(payment);
        }

        // POST: PaymentMethod/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PaymentMethod payment)
        {
            try
            {
                // TODO: Add update logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/PaymentMethod/");
                apiRequest.Content = new ObjectContent<PaymentMethod>(payment, new JsonMediaTypeFormatter());
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

        // GET: PaymentMethod/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/PaymentMethod/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var payment = await response.Content.ReadAsAsync<PaymentMethod>();
            return View(payment);
        }

        // POST: PaymentMethod/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(PaymentMethod payment)
        {
            try
            {
                // TODO: Add delete logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, "api/PaymentMethod/" + payment.id);
                HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
                //var result = await response.Content.ReadAsAsync<PaymentMethod>();
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
