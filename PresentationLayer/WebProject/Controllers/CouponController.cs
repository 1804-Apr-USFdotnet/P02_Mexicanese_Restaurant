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
    public class CouponController : AServiceController
    {
        // GET: Coupon
        public ActionResult Index()
        {
            return RedirectToAction("List");
        }

        public async Task<ActionResult> List()
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Coupon/");
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var coupons = await response.Content.ReadAsAsync<IEnumerable<Coupon>>();
            return View(coupons);
        }

        // GET: Coupon/Details/5
        public async Task<ActionResult> Details(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Coupon/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var coupon = await response.Content.ReadAsAsync<Coupon>();
            return View(coupon);
        }

        // GET: Coupon/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupon/Create
        [HttpPost]
        public async Task<ActionResult> Create(Coupon coupon)
        {
            try
            {
                // TODO: Add insert logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Post, "api/coupon/");
                apiRequest.Content = new ObjectContent<Coupon>(coupon, new JsonMediaTypeFormatter());
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

        // GET: Coupon/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Coupon/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var coupon = await response.Content.ReadAsAsync<Coupon>();
            return View(coupon);
        }

        // POST: Coupon/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(Coupon coupon)
        {
            try
            {
                // TODO: Add update logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/Coupon/");
                apiRequest.Content = new ObjectContent<Coupon>(coupon, new JsonMediaTypeFormatter());
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

        // GET: Coupon/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Coupon/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var coupon = await response.Content.ReadAsAsync<Coupon>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }
            return View(coupon);
        }

        // POST: Coupon/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(Coupon coupon)
        {
            try
            {
                // TODO: Add delete logic here
                HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Delete, "api/Coupon/" + coupon.id);
                HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
                //var result = await response.Content.ReadAsAsync<Coupon>();
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
