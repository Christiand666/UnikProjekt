using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
            return Context.Apartments.Include("ApplicantGoals").Where(x => x.ApartmentID.Equals(ID)).FirstOrDefault();
        }

        public List<Apartment> GetApartment()
        {
            try
            {
                var apartments = Context.Apartments.Include("ApplicantGoals").ToList();

                return apartments;
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
            
            string goalID = Guid.NewGuid().ToString();

            ApplicantGoals appGoal = new ApplicantGoals() {
                GoalsID = goalID,
                Birthdate = apartment.ApplicantGoals.Birthdate,
                Animals = apartment.AllowPets,
                RowVersion = null,
            };

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
                ApplicantGoals = appGoal
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
            var ap = Context.Apartments.Where(x => x.ApartmentID == apartment.ApartmentID).FirstOrDefault();
            if (ap == null)
                throw new Exception("Lejemålet blev ikke fundet");

            ap.Address = apartment.Address ?? ap.Address;
            ap.Zip = apartment.Zip != ap.Zip ? apartment.Zip : ap.Zip;
            ap.City = apartment.City ?? ap.City;
            ap.RoomCount = apartment.RoomCount != ap.RoomCount ? apartment.RoomCount : ap.RoomCount;
            ap.SqrMeter = apartment.SqrMeter != ap.SqrMeter ? apartment.SqrMeter : ap.SqrMeter;
            ap.Floors = apartment.Floors != ap.Floors ? apartment.Floors : ap.Floors;
            ap.Rent = apartment.Rent != ap.Rent ? apartment.Rent : ap.Rent;
            ap.Comment = apartment.Comment ?? ap.Comment;
            ap.AllowPets = Convert.ToBoolean(apartment.AllowPets != ap.AllowPets ? apartment.AllowPets : ap.AllowPets);
            ap.IsShareable = Convert.ToBoolean(apartment.IsShareable != ap.IsShareable ? apartment.IsShareable : ap.IsShareable);
            ap.HasBalcony = Convert.ToBoolean(apartment.HasBalcony != ap.HasBalcony ? apartment.HasBalcony : ap.HasBalcony);
            ap.IsApartment = Convert.ToBoolean(apartment.IsApartment != ap.IsApartment ? apartment.IsApartment : ap.IsApartment);
            ap.IsHouse = Convert.ToBoolean(apartment.IsHouse != ap.IsHouse ? apartment.IsHouse : ap.IsHouse);
            ap.IsRented = Convert.ToBoolean(apartment.IsRented != ap.IsRented ? apartment.IsRented : ap.IsRented);
            ap.ApplicantGoals.Birthdate = apartment.ApplicantGoals.Birthdate != null ? apartment.ApplicantGoals.Birthdate : ap.ApplicantGoals.Birthdate;
            ap.ApplicantGoals.Animals = apartment.AllowPets != ap.AllowPets ? apartment.AllowPets : ap.AllowPets;

            Context.Apartments.Update(ap);
            Context.SaveChanges();
        }

        public void AddWish(Wishlist wish) {
            var wl = Context.WaitingList.Where(x => x.UserID.Equals(wish.UserID)).Where(x => x.ApartmentID.Equals(wish.ApartmentID)).FirstOrDefault();

            if(wl != null)
                throw new Exception("Du er allerede skrevet på listen.");

            WaitingList newWL = new WaitingList() {
                WaitingID = Guid.NewGuid().ToString(),
                UserID = wish.UserID,
                ApartmentID = wish.ApartmentID
            };

            Context.WaitingList.Add(newWL);
            Context.SaveChanges();
        }

        public List<WaitingList> GetAllFromWishlist() {
            return Context.WaitingList.ToList();
        }

        public List<WaitingList> GetWishlistById(string UID) {
            return Context.WaitingList.Where(x => x.UserID.Equals(UID)).ToList();
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
