using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
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

        [HttpPost]
        public async Task<IActionResult> UpdateUser(User user, int UserType) {
            string UID = HttpContext.Session.GetString("UserID");
            string Pwd = HttpContext.Session.GetString("UserPassword");

            user.UserID = UID;
            user.UserType = UserType;

            using(HttpClient client = new HttpClient()) {
                string json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl + "api/User/Update?UID=" + UID + "&Pwd=" + Pwd, data);
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("AlertMessage", "Dine oplysninger blev opdateret!");
                    HttpContext.Session.SetString("AlertType", "Success");

                    return RedirectToAction("Index", "MyPage");
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", result);
                    HttpContext.Session.SetString("AlertType", "Warning");
                }
            }

            return RedirectToAction("Index", "MyPage");
        }

        [HttpGet]
        public async Task<IActionResult> MyWishes() {
            ViewData["Title"] = "Mine ønsker";
            ViewData["Page"] = "MyPage";

            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

            string UID = HttpContext.Session.GetString("UserID");

            List<WaitingList> Results = new List<WaitingList>();
            List<Apartment> ApartmentResults = new List<Apartment>();
            List<Apartment> FinalResult = new List<Apartment>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Apartment/MyWishlist?id=" + UID);
                HttpResponseMessage apartRes = await client.GetAsync("api/Apartment/GetAll");

                if(res.IsSuccessStatusCode && apartRes.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<List<WaitingList>>(response);
                    
                    var apartResponse = apartRes.Content.ReadAsStringAsync().Result;
                    ApartmentResults = JsonConvert.DeserializeObject<List<Apartment>>(apartResponse);

                    foreach(var wish in Results) {
                        foreach(var apart in ApartmentResults) {
                            if(wish.ApartmentID == apart.ApartmentID) {
                                FinalResult.Add(apart);
                            }
                        }
                    }
                } else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View("../MyPage/Account/MyWishes", FinalResult);
        }

        [HttpPost]
        public async Task<IActionResult> RemoveWish(WaitingList wish)
        {
            string UID = HttpContext.Session.GetString("UserID");
            wish.UserID = UID;

            using (HttpClient client = new HttpClient())
            {
                string json = JsonConvert.SerializeObject(wish);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl + "api/WaitingList/Remove", data);
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("AlertMessage", "Du blev fjernet fra listen!");
                    HttpContext.Session.SetString("AlertType", "Info");

                    return RedirectToAction("Index", "MyPage");
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", result);
                    HttpContext.Session.SetString("AlertType", "Warning");
                    return RedirectToAction("Index", "MyPage");
                }
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
