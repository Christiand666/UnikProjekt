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
            return Context.Apartments.Where(x => x.ApartmentID.Equals(ID)).FirstOrDefault();
        }

        public List<Apartment> GetApartment()
        {
            try
            {
                return Context.Apartments.ToList();
            } catch(Exception)
            {
                return null;
            }
        }

        public void Add(Apartment apartment, string LandlordID)
        {
            var CheckApartment = this.Context.Apartments.Where(x => x.Address == apartment.Address).Where(x => x.Zip == apartment.Zip).FirstOrDefault();
            if (CheckApartment != null)
                throw new Exception("Lejemålet eksistere allerede.");
            
            Apartment newApart = new Apartment()
            {
                ApartmentID = Guid.NewGuid().ToString(),
                LandlordID = LandlordID,
                UserID = null,
                Address = apartment.Address,
                Zip = apartment.Zip,
                City = apartment.City,
                RoomCount = apartment.RoomCount,
                SqrMeter = apartment.SqrMeter,
                Floors = apartment.Floors,
                Rent = apartment.Rent,
                Comment = apartment.Comment,
                AllowPets = Convert.ToBoolean(apartment.AllowPets),
                IsShareable = Convert.ToBoolean(apartment.IsShareable),
                HasBalcony = Convert.ToBoolean(apartment.HasBalcony),
                IsApartment = Convert.ToBoolean(apartment.IsApartment),
                IsHouse = Convert.ToBoolean(apartment.IsHouse),
                IsRented = Convert.ToBoolean(apartment.IsRented),
                ApplicantGoalsID = null
            };

            Context.Apartments.Add(newApart);
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
