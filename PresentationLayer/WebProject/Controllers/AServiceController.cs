using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class AServiceController : Controller
    {
        protected static readonly HttpClient HttpClient = new HttpClient(new HttpClientHandler() { UseCookies = false });
        private static readonly Uri serviceUri = new Uri("http://localhost:49971/");//uri is suspect. May need to be changed
        private static readonly string cookieName = "AuthTestCookie";

        protected HttpRequestMessage CreateRequestToService(HttpMethod method, string uri)
        {
            var apiRequest = new HttpRequestMessage(method, new Uri(serviceUri, uri));

            string cookieValue = Request.Cookies[cookieName]?.Value ?? ""; // ?. operator new in C# 7

            apiRequest.Headers.Add("Cookie", new CookieHeaderValue(cookieName, cookieValue).ToString());

            return apiRequest;
        }
    }
}