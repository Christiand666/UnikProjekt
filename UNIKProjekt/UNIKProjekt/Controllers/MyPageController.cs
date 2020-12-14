using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.Classes;
using Domain.Models;
using Domain.Models.Auth;
using Infrastructure;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;
using Newtonsoft.Json;

namespace MVC.Controllers
{
    public class MyPageController : Controller
    {
        private readonly ILogger<MyPageController> _logger;
        private readonly DB db;
        private readonly IUserAuth ua;
        private const string apiUrl = "https://localhost:58197/";

        public MyPageController(ILogger<MyPageController> logger, DB db, IUserAuth ua)
        {
            _logger = logger;
            this.db = db;
            this.ua = ua;
        }

        public IActionResult Index(UserViewModel user)
        {
            ViewData["Page"] = "MyPage";

            if (!ua.isLoggedIn())
            {
                ViewData["Title"] = "Log Ind";

                return View("Views/Login", user);
            }
            else
            {
                ViewData["Title"] = "Min Side";

                return View("Views/MyPage");
            }
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> SignIn(UserLogin user)
        {
            if(!string.IsNullOrEmpty(user.Email) && !string.IsNullOrEmpty(user.Password)) {
                using(HttpClient client = new HttpClient()) {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync(apiUrl + "api/User/GetSalt?email=" + user.Email);
                    string result = response.Content.ReadAsStringAsync().Result;

                    try {
                        SaltTransfer saltReturn = JsonConvert.DeserializeObject<SaltTransfer>(result);
                        string salt = saltReturn.Salt;

                        if(response.IsSuccessStatusCode) {
                            string pw = Hashing.Hash(user.Password + salt);
                            
                            UserLogin newUser = new UserLogin() {
                                Password = pw,
                                Email = user.Email
                            };

                            HttpResponseMessage loginResponse = await client.GetAsync(apiUrl + "api/User/SignIn?Email=" + newUser.Email + "&Password=" + newUser.Password);
                            string loginResult = loginResponse.Content.ReadAsStringAsync().Result;
                            
                            User UserData = JsonConvert.DeserializeObject<User>(loginResult);

                            HttpContext.Session.SetString("AlertMessage", "Velkommen tilbage " + UserData.Fname + "!");
                            HttpContext.Session.SetString("AlertType", "Success");

                            // Storing user data
                            HttpContext.Session.SetString("UserID", UserData.UserID);
                            HttpContext.Session.SetString("UserPassword", UserData.Password);
                            HttpContext.Session.SetString("UserEmail", UserData.Email);

                            return RedirectToAction("Index");
                        } else {
                            HttpContext.Session.SetString("AlertMessage", result);
                            HttpContext.Session.SetString("AlertType", "Error");
                        }
                    } catch(Exception) {
                        HttpContext.Session.SetString("AlertMessage", "Log ind fejl.");
                        HttpContext.Session.SetString("AlertType", "Error");

                        return RedirectToAction("Index", user); // Redirects back to (public IActionResult Index) with given post-request.
                    }
                }
            } else {
                HttpContext.Session.SetString("AlertMessage", "Du skal udfylde alle felter.");
                HttpContext.Session.SetString("AlertType", "Error");
            }

            return RedirectToAction("Index", user); // Redirects back to (public IActionResult Index) with given post-request.
        }

        public IActionResult QuickSignIn(UserData ud)
        {
            HttpContext.Session.SetString("LoggedIn", "1"); // Logs user in (Very insecure)
            HttpContext.Session.SetString("User", "HackMan@Hack.this");

            ud.UserID = "hack123";
            ud.isLoggedIn = true;
            ud.isAdmin = false;
            ud.isLandlord = false;

            return RedirectToAction("Index");
        }

        public IActionResult Register(RegisterViewModel register)
        {
            if (HttpContext.Session.GetString("LoggedIn") != null)
            {
                return RedirectToAction("Index");
            }

            ViewData["Page"] = "MyPage";
            ViewData["Title"] = "Registrer";
            return View(register);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterViewModel register)
        {
            if(register.Password != register.ConfirmPassword) {
                HttpContext.Session.SetString("AlertMessage", "Adgangskoderne matcher ikke.");
                HttpContext.Session.SetString("AlertType", "Error");

                return RedirectToAction("Register", register);
            }

            Random rnd = new Random();

            string salt = Hashing.Hash(rnd.Next(1000,9999).ToString(), 16);
            string password = Hashing.Hash(register.Password + salt);

            UserDetails ud = new UserDetails() {
                DetailsID = Guid.NewGuid().ToString(),
                Phone = register.Phone,
                Birthdate = Convert.ToDateTime(register.Birthday),
                Address = register.Address,
                Country = register.Country,
                Zip = register.Zip
            };

            User user = new User() {
                UserID = Guid.NewGuid().ToString(),
                Fname = register.Fname,
                Lname = register.Lname,
                Email = register.Email,
                Password = password,
                UserDetails = ud,
                Salt = salt
            };

            using(HttpClient client = new HttpClient()) {
                string json = JsonConvert.SerializeObject(user);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl + "api/User/Create", data);
                string result = response.Content.ReadAsStringAsync().Result;

                if(response.IsSuccessStatusCode) {
                    HttpContext.Session.SetString("AlertMessage", "Du er nu medlem af FAKEBOVIA, og kan nu logge ind!");
                    HttpContext.Session.SetString("AlertType", "Success");

                    return RedirectToAction("Index");
                } else {
                    HttpContext.Session.SetString("AlertMessage", result);
                    HttpContext.Session.SetString("AlertType", "Warning");
                }
            }

            return RedirectToAction("Register", register);
        }

        public IActionResult Profile()
        {
            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index");
            }

            ViewData["Title"] = "Profil";
            ViewData["Page"] = "MyPage";

            return View("Account/Profile");
        }

        public IActionResult SignOut()
        {
            HttpContext.Session.Remove("UserID");
            HttpContext.Session.Remove("UserPassword");
            HttpContext.Session.Remove("UserEmail");

            /** Adds a logout alert message to a session **/
            HttpContext.Session.SetString("AlertMessage", "Du er blevet logget ud.");
            HttpContext.Session.SetString("AlertType", "Info");

            return RedirectToAction("Index"); // Redirects user back to the login page.
        }
    }
}
