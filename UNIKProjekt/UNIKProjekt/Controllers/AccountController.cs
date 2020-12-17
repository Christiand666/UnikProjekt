using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Connection;
using Domain.Models;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using UNIKProjekt.Models;

namespace MVC.Controllers
{
    [Route("MyPage/[Controller]/[Action]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserAuth ua;
        private readonly string apiUrl = APIConnection.GetConnection();

        public AccountController(ILogger<AccountController> logger, IUserAuth ua)
        {
            _logger = logger;
            this.ua = ua;
        }

        public async Task<IActionResult> Information()
        {
            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

            ViewData["Page"] = "MyPage";
            ViewData["Title"] = "Mine Oplysninger";

            User Results = new User();
            string id = HttpContext.Session.GetString("UserID");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/User/Get?id=" + id);

                if (res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<User>(response);
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View("../MyPage/Account/Information", Results);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
