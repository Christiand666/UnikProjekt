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
    public class LandlordController : Controller
    {
        private readonly ILogger<LandlordController> _logger;
        private readonly IUserAuth ua;
        private readonly string apiUrl = APIConnection.GetConnection();

        public LandlordController(ILogger<LandlordController> logger, IUserAuth ua)
        {
            _logger = logger;
            this.ua = ua;
        }

        public IActionResult Add(Apartment apartmentModel)
        {
            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

            ViewData["Page"] = "MyPage";
            return View("../MyPage/Landlord/Add", apartmentModel);
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<IActionResult> AddApartment(Apartment apartmentModel) {
            string LandlordID = "";
            string Password = "";

            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

            if(HttpContext.Session.GetString("UserID") != null) {
                LandlordID = HttpContext.Session.GetString("UserID");
                Password = HttpContext.Session.GetString("UserPassword");
            } else {
                HttpContext.Session.SetString("AlertMessage", "Der skete en ukendt fejl. Prøv igen.");
                HttpContext.Session.SetString("AlertType", "Error");
                return RedirectToAction("../MyPage/Landlord/Add", apartmentModel);
            }

            using(HttpClient client = new HttpClient()) {
                string json = JsonConvert.SerializeObject(apartmentModel);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl + "api/Apartment/Create/?LandlordID=" + LandlordID + "&Password=" + Password + "&", data);
                string result = response.Content.ReadAsStringAsync().Result;

                if(response.IsSuccessStatusCode) {
                    HttpContext.Session.SetString("AlertMessage", "Lejemålet blev oprettet!");
                    HttpContext.Session.SetString("AlertType", "Success");

                    return RedirectToAction("Index", "MyPage", apartmentModel);
                } else {
                    HttpContext.Session.SetString("AlertMessage", result);
                    HttpContext.Session.SetString("AlertType", "Warning");
                    return RedirectToAction("/MyPage/Landlord/Add", apartmentModel);
                }
            }
        }

        [HttpGet]
        public async Task<IActionResult> EditApartments() {
            ViewData["Page"] = "MyPage";

            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

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

            return View("../MyPage/Landlord/EditApartments", Results);
        }

        [HttpGet]
        public async Task<IActionResult> EditApartment(string ID) {
            ViewData["Page"] = "MyPage";

            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

            Apartment Results = new Apartment();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage res = await client.GetAsync("api/Apartment/GetItem?id=" + ID);

                if(res.IsSuccessStatusCode)
                {
                    var response = res.Content.ReadAsStringAsync().Result;
                    Results = JsonConvert.DeserializeObject<Apartment>(response);
                } else
                {
                    HttpContext.Session.SetString("AlertMessage", "API Error");
                    HttpContext.Session.SetString("AlertType", "Error");
                }
            }

            return View("../MyPage/Landlord/EditApartment", Results);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateApartment(Apartment apartment, string ID) {
            string UserID = HttpContext.Session.GetString("UserID");
            string Password = HttpContext.Session.GetString("UserPassword");

            apartment.ApartmentID = ID;

            using(HttpClient client = new HttpClient()) {
                string json = JsonConvert.SerializeObject(apartment);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync(apiUrl + "api/Apartment/Update?UID=" + UserID + "&Pwd=" + Password + "&", data);
                string result = response.Content.ReadAsStringAsync().Result;

                if (response.IsSuccessStatusCode)
                {
                    HttpContext.Session.SetString("AlertMessage", "Lejemålet blev opdateret!");
                    HttpContext.Session.SetString("AlertType", "Success");

                    return RedirectToAction("EditApartments");
                }
                else
                {
                    HttpContext.Session.SetString("AlertMessage", result);
                    HttpContext.Session.SetString("AlertType", "Warning");
                }
            }

            return RedirectToAction("EditApartments");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
