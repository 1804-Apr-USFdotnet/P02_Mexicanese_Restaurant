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
    public class OrderController : AServiceController
    {
        private static readonly HttpClient httpClient = new HttpClient();
        // GET: Order

        public ActionResult Index()
        {
            return RedirectToAction("List");
        }
        public async Task<ActionResult> Details(int id)
        {

            //HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Order/" + id);
            //HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            //if (!response.IsSuccessStatusCode)
            //{
            //    return View("Error");
            //}

            //var order = await response.Content.ReadAsAsync<Order>();
            //List<OrderItem> list = order.OrderItems.ToList();
            //return View(order);
            List<OrderViewModel> viewlist = new List<OrderViewModel>();
            OrderViewModel ovm = null;
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Order/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var orders = await response.Content.ReadAsAsync<Order>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            ovm = new OrderViewModel();
            ovm.order = orders;
            HttpRequestMessage apiRequest1 = CreateRequestToService(HttpMethod.Get, "api/Address/" + orders.AddressID);
            response = await HttpClient.SendAsync(apiRequest1);
            var address = await response.Content.ReadAsAsync<Address>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            ovm.address = address;
            HttpRequestMessage apiRequest2 = CreateRequestToService(HttpMethod.Get, "api/PaymentMethod/" + orders.PaymentID);
            response = await HttpClient.SendAsync(apiRequest2);
            var payment = await response.Content.ReadAsAsync<PaymentMethod>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            ovm.payment = payment;
            viewlist.Add(ovm);
            return View(ovm);

        }

        public async Task<ActionResult> List()
        {
            List<OrderViewModel> viewlist = new List<OrderViewModel>();
            OrderViewModel ovm = null;
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Order/");
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }
            var orders = await response.Content.ReadAsAsync<IEnumerable<Order>>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }
            foreach (var order in orders)
            {
                ovm = new OrderViewModel();
                ovm.order = order;
                HttpRequestMessage apiRequest1 = CreateRequestToService(HttpMethod.Get, "api/Address/" + order.AddressID);
                response = await HttpClient.SendAsync(apiRequest1);
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error");
                }
                var address = await response.Content.ReadAsAsync<Address>();
                ovm.address = address;
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error" + response.StatusCode);
                }
                HttpRequestMessage apiRequest2 = CreateRequestToService(HttpMethod.Get, "api/PaymentMethod/" + order.PaymentID);
                response = await HttpClient.SendAsync(apiRequest2);
                var payment = await response.Content.ReadAsAsync<PaymentMethod>();
                ovm.payment = payment;
                if (!response.IsSuccessStatusCode)
                {
                    return View("Error" + response.StatusCode);
                }
                viewlist.Add(ovm);
            }

            //if (!response.IsSuccessStatusCode)
            //{
            //    return View("Error");
            //}

            //var order = await response.Content.ReadAsAsync<IEnumerable<Order>>();
            //List<OrderItem> list = order.OrderItems.ToList();
            return View(viewlist);

        }
        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        { 
           
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Get, "api/Order/" + id);
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);
            var order = await response.Content.ReadAsAsync<Order>();
            if (!response.IsSuccessStatusCode)
            {
                return View("Error" + response.StatusCode);
            }


            return View(order);

        }
        [HttpPost]
        public async Task<ActionResult> Edit(Order ord)
        {
            HttpRequestMessage apiRequest = CreateRequestToService(HttpMethod.Put, "api/Order/");
            apiRequest.Content = new ObjectContent<Order>(ord, new JsonMediaTypeFormatter());
            HttpResponseMessage response = await HttpClient.SendAsync(apiRequest);

            if (!response.IsSuccessStatusCode)
            {
                return View("Error");
            }

            var order = await response.Content.ReadAsAsync<Order>();
            //List<OrderItem> list = order.OrderItems.ToList();
            return RedirectToAction("List");

        }

        
    }
}