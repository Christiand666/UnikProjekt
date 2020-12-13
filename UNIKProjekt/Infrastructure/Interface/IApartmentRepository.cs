using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IApartmentRepository : IDisposable
    {
        IEnumerable<Apartment> GetApartment();
        Apartment GetApartmentsByID(Guid ID);

        void Add(Apartment apartment);
        void Delete(Apartment apartment);
        void Update(Apartment apartment);
        void Save();
    }
}
