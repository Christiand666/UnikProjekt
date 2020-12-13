using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    class MockUserRepository : IUserRepository
    {
        private bool disposedValue;

        private List<User> users = new List<User>();
        private List<UserDetails> userDetailList = new List<UserDetails>();

        public void Add(User User)
        {
            users.Add(User);
        }

        public void CreateUpdateUserDetails(UserDetails user)
        {
            throw new NotImplementedException();
        }

        public void Delete(User User)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(User User)
        {
            throw new NotImplementedException();
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
