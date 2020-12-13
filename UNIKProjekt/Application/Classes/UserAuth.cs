using Microsoft.AspNetCore.Http;
using Infrastructure.Interface;

namespace Application.Classes
{
    public class UserAuth : IUserAuth
    {
        private readonly IHttpContextAccessor _HttpContext;

        public UserAuth(IHttpContextAccessor _HttpContext)
        {
            this._HttpContext = _HttpContext;
        }

        public bool isLoggedIn()
        {
            var httpContext = _HttpContext.HttpContext;

            if (httpContext.Session.GetString("LoggedIn") != null)
                return true;

            return false;
        }

        public bool isAdmin()
        {
            if (isLoggedIn())
            { // Checks if user is logged in before checking for admin privileges.
                // Only admin code pls
            }
            return false;
        }

        public bool isLandlord()
        {
            if (isLoggedIn())
            { // Checks if user is logged in before checking for landlord privileges.
                // Code pls
            }
            return false;
        }

        public bool isUser()
        {
            if (!isAdmin() && !isLandlord())
                return true;
            return false;
        }
    }
}