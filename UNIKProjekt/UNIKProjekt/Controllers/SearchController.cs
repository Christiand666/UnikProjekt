using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Domain.Models;
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

        [HttpPost]
        public IActionResult Index()
        {
            ViewData["Page"] = "Search";

            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new Apartment { }));
            content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");
            //var response = await client.PostAsync("API/GetAllApartments");

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
