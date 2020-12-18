using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Connection;
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
        //private readonly IAPI con;
        private readonly string apiUrl = APIConnection.GetConnection();

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Page"] = "Search";
            ViewData["Title"] = "Søg bolig";

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

        [HttpPost]
        [Route("Search/AddToWishlist/{id}")]
        public async Task<IActionResult> AddToWishlist(string id) {
            string UserID = HttpContext.Session.GetString("UserID");

            WaitingList wish = new WaitingList() {
                UserID = UserID,
                ApartmentID = id
            };
            
            using(HttpClient client = new HttpClient()) {
                string json = JsonConvert.SerializeObject(wish);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl + "api/WaitingList/Add", data);
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("AlertMessage", "Du er blevet skrevet op!!");
                    HttpContext.Session.SetString("AlertType", "Success");

                    return RedirectToAction("Index");
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", result);
                    HttpContext.Session.SetString("AlertType", "Warning");
                }
            }

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
