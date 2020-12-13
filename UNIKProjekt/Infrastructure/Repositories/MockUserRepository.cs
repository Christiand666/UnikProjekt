using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    class MockUserRepository : IUserRepository
    {
        private bool disposedValue;

        private List<User> users = new List<User>();

        public void Add(User User)
        {
            users.Add(User);
        }

        public void CreateUpdateUserDetails(UserDetails user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User user)
        {
            users.Remove(user);
        }

        public bool EmailExists(string Email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public User GetUsersByID(string ID)
        {
            return users.Where(x => x.UserID == ID).FirstOrDefault();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User user)
        {
            var match = users.Where(x => x.UserID == user.UserID).FirstOrDefault();
            match = user;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
