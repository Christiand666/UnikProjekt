using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IUserRepository : IDisposable
    {
        IEnumerable<User> GetUsers();
        User GetUsersByID(string ID);
        bool EmailExists(string Email);
        void Add(User User, UserDetails ud);
        void Delete(User User);
        void Update(User User, UserDetails ud);
        void Save();
        void CreateUpdateUserDetails(UserDetails user);
    }
}
