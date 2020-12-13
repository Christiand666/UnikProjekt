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

        public SearchController(ILogger<SearchController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Page"] = "Search";

            string apiUrl = "https://localhost:58197/";

            using(var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Apartment/GetAll");

                if(res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;

                    HttpContext.Session.SetString("AlertMessage", response);
                    HttpContext.Session.SetString("AlertType", "Success");
                } else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View();
        }

        public IActionResult Item(int id)
        {
            ViewData["Page"] = "Search";

            if (id <= 0)
            {
                //throw new Exception("Missing id.");
                ViewBag.ID = "Missing id.";
            }
            else
            {
                ViewBag.ID = id;
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
