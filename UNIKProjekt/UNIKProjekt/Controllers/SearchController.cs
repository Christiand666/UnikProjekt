using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UNIKProjekt.Models;

namespace MVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<SearchController> _logger;

        private const string apiUrl = "https://localhost:58197/";

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Page"] = "Search";

            List<Apartment> Results = new List<Apartment>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Apartment/GetAll");

                if(res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<List<Apartment>>(response);
                } else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View(Results);
        }

        public async Task<IActionResult> Item(string id)
        {
            ViewData["Page"] = "Search";

            Apartment Results = new Apartment();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Apartment/GetItem?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<Apartment>(response);
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View(Results);
        }

        public async Task<IActionResult> AddToWishList(string id, string uid) {

            /*using(var client = new HttpClient()) {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.PostAsync("api/Apartment/AddToWishlist", wishlist);

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<Apartment>(response);
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }*/

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
