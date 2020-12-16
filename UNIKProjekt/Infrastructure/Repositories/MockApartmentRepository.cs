using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Repositories
{
    public class MockApartmentRepository : IApartmentRepository
    {
        private bool IsDisposed;

        public void Add(Apartment apartment, string LandlordID)
        {
            throw new NotImplementedException();
        }

        public void GetUserSalt(string Email)
        {
            throw new NotImplementedException();
        }

        public void Delete(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public List<Apartment> GetApartment()
        {
            throw new NotImplementedException();
        }

        public Apartment GetApartmentByID(string ID)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Update(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
       
            }
            this.IsDisposed = true;
        }

  
        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
