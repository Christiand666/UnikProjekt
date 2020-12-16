using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IApartmentRepository : IDisposable
    {
        List<Apartment> GetApartment();
        Apartment GetApartmentByID(string ID);

        void Add(Apartment apartment, string LandlordID);
        void Delete(Apartment apartment);
        void Update(Apartment apartment);
        void Save();
    }
}
