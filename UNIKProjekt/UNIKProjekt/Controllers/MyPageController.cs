using Application.Classes;
using Infrastructure;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Models;

namespace MVC.Controllers
{
    public class MyPageController : Controller
    {
        private readonly ILogger<MyPageController> _logger;
        private readonly DB db;
        private readonly IUserAuth ua;

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
        public IActionResult SignIn(UserViewModel user)
        {

            //UsersHandlers.Login(user.Email, user.Password);



            if (user.Email == "dev@dev.com" && user.Password == "12345678")
            {
                HttpContext.Session.SetString("LoggedIn", "1"); // Logs user in (Very insecure)
                HttpContext.Session.SetString("User", user.Email); // Pust users email in a session, for later use.

                /** Adds alert message to a session **/
                HttpContext.Session.SetString("AlertMessage", "Velkommen tilbage " + user.Email + "!");
                HttpContext.Session.SetString("AlertType", "Success");
            }
            else
            {
                /** Adds alert message to a session **/
                HttpContext.Session.SetString("AlertMessage", "Fejl i email eller adgangskode.");
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

        public IActionResult Register()
        {
            if (HttpContext.Session.GetString("LoggedIn") != null)
            {
                return RedirectToAction("Index");
            }

            ViewData["Page"] = "MyPage";
            ViewData["Title"] = "Registrer";
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult RegisterUser(RegisterViewModel register)
        {
            var UserRep = new UserRepository(db);

            string pw = Hashing.Hash(register.Password);

            HttpContext.Session.SetString("AlertMessage", "Din adgangskode er: " + pw);
            HttpContext.Session.SetString("AlertType", "Error");

            return View("Register");

            // try {
            //     if(UserRep.EmailExists(register.Email)) {
            //         


            //     } else {
            //         HttpContext.Session.SetString("AlertMessage", "Good to go.");
            //         HttpContext.Session.SetString("AlertType", "Success");
            //         return View("Register");
            //     }
            // } catch(Exception e) {
            //     HttpContext.Session.SetString("AlertMessage", e.ToString());
            //     HttpContext.Session.SetString("AlertType", "Error");
            // }

            // return RedirectToAction("Index");
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
            HttpContext.Session.Remove("LoggedIn"); // Clears users logged in session aka. signs the user out.
            HttpContext.Session.Remove("User"); // Clears the users email from the session.

            /** Adds a logout alert message to a session **/
            HttpContext.Session.SetString("AlertMessage", "Du er blevet logget ud.");
            HttpContext.Session.SetString("AlertType", "Info");

            return RedirectToAction("Index"); // Redirects user back to the login page.
        }
    }
}
