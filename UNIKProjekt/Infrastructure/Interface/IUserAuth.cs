using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IUserAuth
    {
        bool isLoggedIn();
        bool isUser();
        bool isAdmin();
        bool isLandlord();
    }
}
