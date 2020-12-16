using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IUserAuth
    {
        bool isLoggedIn();
        bool isLoggedIn(string UserID, string Password);
        bool isUser();
        bool isAdmin();
        bool isAdmin(string UserID, string Password);
        bool isLandlord();
        bool isLandlord(string UserID, string Password);
    }
}
