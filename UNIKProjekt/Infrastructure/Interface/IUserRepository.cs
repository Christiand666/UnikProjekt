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
        void Add(User User);
        void Delete(User User);
        void Update(User User);
        void Save();
        void CreateUpdateUserDetails(UserDetails user);
    }
}
