using Microsoft.AspNetCore.Http;
using Infrastructure.Interface;
using Application.Handlers;

namespace Application.Classes
{
    public class UserAuth : IUserAuth
    {
        private readonly IHttpContextAccessor _HttpContext;
        private readonly IUserRepository userRep;

        public UserAuth(IHttpContextAccessor _HttpContext, IUserRepository userRep)
        {
            this._HttpContext = _HttpContext;
            this.userRep = userRep;
        }

        public bool isLoggedIn()
        {
            var httpContext = _HttpContext.HttpContext;

            if(
                httpContext.Session.GetString("UserID") != null &&
                httpContext.Session.GetString("UserPassword") != null &&
                httpContext.Session.GetString("UserEmail") != null
            ) {
                string pw = httpContext.Session.GetString("UserPassword");
                string id = httpContext.Session.GetString("UserID");

                //throw new System.Exception(userHandler.CheckUserSignedIn(id, pw).ToString());
                
                if(userRep.CheckUserSignedIn(id, pw))
                    return true;
            }
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