using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace UNIKProjekt.Controllers
{
    [Route("/MyPage/[Controller]/[Action]")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly string apiUrl = APIConnection.GetConnection();

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewData["Page"] = "MyPage";
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> EditUsers() {
            ViewData["Page"] = "MyPage";

            List<User> Results = new List<User>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/User/GetAll");

                if(res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<List<User>>(response);
                } else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View("../MyPage/Admin/EditUsers", Results);
        }

        [HttpGet]
        public async Task<IActionResult> EditUser(string ID) {
            ViewData["Page"] = "MyPage";

            User Results = new User();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/User/Get?id=" + ID);

                if(res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<User>(response);
                } else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View("../MyPage/Admin/EditUser", Results);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        //[Route("/MyPage/Admin/UpdateUser")]
        public async Task<IActionResult> UpdateUser(User userUpdate, string ID) {
            string UserID = HttpContext.Session.GetString("UserID");
            string Password = HttpContext.Session.GetString("UserPassword");

            //user = userUpdate;

            using(HttpClient client = new HttpClient()) {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/User/Get?id=" + ID);

                if (res.IsSuccessStatusCode)
                {
                    User userDataResults = new User();

                    var userDataResponse = res.Content.ReadAsStringAsync().Result;
                    userDataResults = JsonConvert.DeserializeObject<User>(userDataResponse);

                    User user = new User()
                    {
                        UserID = ID,
                        UserType = userUpdate.UserType,
                        Fname = userUpdate.Fname != null ? userUpdate.Fname : userDataResults.Fname,
                        Lname = userUpdate.Lname != null ? userUpdate.Lname : userDataResults.Lname,
                        Email = userUpdate.Email != null ? userUpdate.Email : userDataResults.Email,
                        Password = userUpdate.Password != null ? userUpdate.Password : userDataResults.Password,
                        Salt = userUpdate.Salt != null ? userUpdate.Salt : userDataResults.Salt,
                    };

                    string json = JsonConvert.SerializeObject(user);
                    var data = new StringContent(json, Encoding.UTF8, "application/json");

                    HttpContext.Session.SetString("AlertMessage", json);
                    HttpContext.Session.SetString("AlertType", "Success");

                    HttpResponseMessage response = await client.PostAsync(apiUrl + "api/User/Update?UserID=" + UserID + "&Password=" + Password + "&", data);
                    string result = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        HttpContext.Session.SetString("AlertMessage", "Brugeren blev opdateret!");
                        HttpContext.Session.SetString("AlertType", "Success");

                        return RedirectToAction("EditUsers", "Admin");
                    }
                    else
                    {
                        HttpContext.Session.SetString("AlertMessage", result);
                        HttpContext.Session.SetString("AlertType", "Warning");
                    }
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return RedirectToAction("EditUsers", "Admin");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
