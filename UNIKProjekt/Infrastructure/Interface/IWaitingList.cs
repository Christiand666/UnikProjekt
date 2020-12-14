using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interface
{
    public interface IWaitingList
    {
        void Create(WaitingList list);

        public void Remove(string UserID, string Apartment);

        public List<Apartment> GetApartments(string UserID);
    }
}
