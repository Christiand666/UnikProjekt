using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UNIKProjekt.Models;

namespace UNIKProjekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Page"] = "Home";
            return View();
        }

        [Route("About")]
        public IActionResult About()
        {
            ViewData["Page"] = "About";
            return View();
        }

        [Route("News")]
        public IActionResult News()
        {
            ViewData["Page"] = "News";
            return View();
        }

        [Route("News/[Action]/{id}/{title}")]
        public IActionResult Article(int id, string title)
        {
            ViewData["Page"] = "News";

            return View("News/Article");
        }

        [Route("Contact")]
        public IActionResult Contact()
        {
            ViewData["Page"] = "Contact";
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
