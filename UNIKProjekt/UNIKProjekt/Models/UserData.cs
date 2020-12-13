using System;
namespace MVC.Models
{
    public class UserData
    {
        public string UserID { get; set; }
        public bool isAdmin { get; set; }
        public bool isLandlord { get; set; }
        public bool isLoggedIn { get; set; }
    }
}