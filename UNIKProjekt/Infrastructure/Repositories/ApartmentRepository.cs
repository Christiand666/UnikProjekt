using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly IDB Context;
        private bool IsDisposed = false;
        public ApartmentRepository(IDB dB)
        {
            this.Context = dB;
        }

        public Apartment GetApartmentByID(string ID)
        {
            return Context.Apartments.Where<Apartment>(x => x.ApartmentID == ID.ToString()).FirstOrDefault();
        }

        public List<Apartment> GetApartment()
        {
            try
            {
                return Context.Apartments.Where(x => x.IsRented.Equals(false)).ToList();
            } catch(Exception)
            {
                return null;
            }
        }

        public void Add(Apartment apartment)
        {
            var CheckUser = this.Context.Apartments.Where(x => x.Address == apartment.Address || x.Zip == apartment.Zip).FirstOrDefault();
            if (CheckUser != null)
                throw new Exception("Brugeren eksistere allerede, Login eller tryk glemt kodeord");

            Context.Apartments.Add(apartment);
            Context.SaveChanges();

        }

        public void Delete(Apartment apartment)
        {
            var CheckUser = this.Context.Apartments.Where(x => x.Address == apartment.Address || x.Zip == apartment.Zip).FirstOrDefault();
            if (CheckUser == null)
                throw new Exception("Adressen blev ikke fundet check om det er de rigtige kreterier");

            Context.Apartments.Remove(apartment);
        }


        public void Update(Apartment apartment)
        {
            var contextusers = Context.Apartments.Where(x => x.ApartmentID == apartment.ApartmentID).FirstOrDefault();
            if (contextusers == null)
                throw new Exception("brugeren blev ikke fundet");

            if (Context.Apartments.Any(x => x.Address == apartment.Address || x.Zip == apartment.Zip)) throw new Exception("Adressen er allerede taget i brug");
          

            contextusers.Address = apartment.Address;
            contextusers.Zip = apartment.Zip;
            contextusers.City = apartment.City;
            contextusers.RoomCount = apartment.RoomCount;
            contextusers.SqrMeter = apartment.SqrMeter;
            contextusers.Floors = apartment.Floors;
            contextusers.Rent = apartment.Rent;
            contextusers.Comment = apartment.Comment;
            contextusers.AllowPets = apartment.AllowPets;
            contextusers.IsShareable = apartment.IsShareable;
            contextusers.HasBalcony = apartment.HasBalcony;
            contextusers.IsApartment = apartment.IsApartment;
            contextusers.IsHouse = apartment.IsHouse;


        }
        public void Save()
        {
            Context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.IsDisposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.IsDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
