using Domain.Models;
using Domain.Models.Auth;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUsersByID(string ID);
        User SignIn(UserLogin user);
        string GetUserSalt(string Email);
        bool CheckUserSignedIn(string UserID, string Password);
        bool CheckUserType(string UserID, int UserType);
        bool EmailExists(string Email);
        void Add(User User);
        void Delete(User User);
        void Update(User User);
        void Save();
        void CreateUpdateUserDetails(UserDetails user);
    }
}
