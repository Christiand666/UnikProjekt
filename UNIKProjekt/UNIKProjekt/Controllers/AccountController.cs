using System.Diagnostics;
using Infrastructure.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UNIKProjekt.Models;

namespace MVC.Controllers
{
    [Route("MyPage/[Controller]/[Action]")]
    public class AccountController : Controller
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IUserAuth ua;

        public AccountController(ILogger<AccountController> logger, IUserAuth ua)
        {
            _logger = logger;
            this.ua = ua;
        }

        public IActionResult Information()
        {
            if (!ua.isLoggedIn())
            {
                HttpContext.Session.SetString("AlertMessage", "Adgang nægtet. Venligst log ind først.");
                HttpContext.Session.SetString("AlertType", "Warning");

                return RedirectToAction("Index", "MyPage");
            }

            ViewData["Page"] = "MyPage";
            ViewData["Title"] = "Mine Oplysninger";
            return View("../MyPage/Account/Information");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
