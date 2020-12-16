using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
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
        private const string apiUrl = "https://localhost:58197/";

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

            HttpContext.Session.SetString("AlertMessage", "Alle felter med en '*', skal udfyldes!");
            HttpContext.Session.SetString("AlertType", "Error");
            return RedirectToAction("../MyPage/Landlord/Add", apartmentModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
