using Microsoft.AspNetCore.Http;
using Infrastructure.Interface;

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
                
                if(userRep.CheckUserSignedIn(id, pw))
                    return true;
            }
            return false;
        }

        public bool isLoggedIn(string UserID, string Password) {
            if(userRep.CheckUserSignedIn(UserID, Password))
                return true;

            return false;
        }

        public bool isAdmin()
        {
            if (isLoggedIn())
            { // Checks if user is logged in before checking for admin privileges.
                var httpContext = _HttpContext.HttpContext;

                string id = httpContext.Session.GetString("UserID");

                if(userRep.CheckUserType(id, 2)) {
                    return true;
                }
            }
            return false;
        }

        public bool isAdmin(string UserID, string Password) {
            if(isLoggedIn(UserID, Password)) {
                if(userRep.CheckUserType(UserID, 2)) {
                    return true;
                }
            }
            return false;
        }

        public bool isLandlord()
        {
            if (isLoggedIn())
            { // Checks if user is logged in before checking for landlord privileges.
                var httpContext = _HttpContext.HttpContext;

                string id = httpContext.Session.GetString("UserID");

                if(userRep.CheckUserType(id, 1)) {
                    return true;
                }
            }
            return false;
        }
        
        public bool isLandlord(string UserID, string Password) {
            if(isLoggedIn(UserID, Password)) {
                if(userRep.CheckUserType(UserID, 1)) {
                    return true;
                }
            }
            return false;
        }

        public bool isUser()
        {
            if(isLoggedIn()) {
                if (!isAdmin() && !isLandlord())
                    return true;
            }
            return false;
        }
    }
}