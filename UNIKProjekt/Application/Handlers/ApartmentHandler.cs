﻿using Application.Classes;
using Domain.Models;
using Infrastructure.Interface;
using Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers
{
    public interface IApartmentHandler
    {
        void CreateApartment(Apartment apartment, string LandlordID, string Password);
        void UpdateApartment(Apartment apartment, string LandlordID, string Password);
        void DeleteApartment(string ID, string LandlordID, string Password);
        void AddWish(Wishlist wish);
        List<Apartment> GetBest(ApartmentDemands demands, int amount);
        List<Apartment> GetAll();
        Apartment GetApartment(string ID);
        List<Apartment> GetAllOwnedApartmentsForLandLords(string UserID, string Password);
        List<WaitingList> GetAllFromWishlist();
        List<WaitingList> GetWishlistById(string UID);
    }

    public class ApartmentHandler : IApartmentHandler
    {
        private readonly IApartmentRepository apartmentRepository;
        //private readonly IHttpContextAccessor _HttpContext;
        private readonly IUserAuth userAuth;
        private readonly IDB Context;

        public ApartmentHandler(IApartmentRepository apartmentRepository, IUserAuth userAuth)
        {
            this.apartmentRepository = apartmentRepository;
            //this._HttpContext = _HttpContext;
            this.userAuth = userAuth;
        }

        //UserAuth userAuth = new UserAuth(_HttpContext, UserRepository);

        public void CreateApartment(Apartment apartment, string LandlordID, string Password)
        {
            if (!userAuth.isLandlord(LandlordID, Password))
                throw new Exception("ingen privilegier" + LandlordID + " pw " + Password);
                
            try
            {
                apartmentRepository.Add(apartment, LandlordID);
                apartmentRepository.Save();
            }
            catch (Exception e)
            {
                throw e;
                //in da treashcan
            }
        }
        public void UpdateApartment(Apartment apartment, string LandlordID, string Password)
        {
            //var ApartmentUser = Context.Apartments.Where(x => x.ApartmentID == apartment.ApartmentID).FirstOrDefault();

            if (!userAuth.isLandlord(LandlordID, Password) || !userAuth.isAdmin(LandlordID, Password))
                throw new Exception("ingen privilegier");
    
            if (apartmentRepository.GetApartmentByID(apartment.ApartmentID) != null)
            {
                try
                {
                    apartmentRepository.Update(apartment);
                    apartmentRepository.Save();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            else
            {
                //apartment your trying to update does not exist//
            }

        }
        public void DeleteApartment(string apartmentID, string LandlordID, string Password)
        {
            if (!userAuth.isLandlord(LandlordID, Password))
                throw new Exception("ingen privilegier");
            Apartment apartment = apartmentRepository.GetApartmentByID(apartmentID);

            apartmentRepository.Delete(apartment);
            apartmentRepository.Save();

        }
        public List<Apartment> GetBest(ApartmentDemands demands, int amount)
        {
            SortedDictionary<double, Apartment> matches = new SortedDictionary<double, Apartment>();

            IEnumerable<Apartment> apartments = apartmentRepository.GetApartment();

            foreach (Apartment a in apartments)
            {
                double scoreTreshhold = 7; //WIP number

                //Remember to add factors here
                int petMatch = demands.AllowPets ? Convert.ToInt32(a.AllowPets) : 0;
                double roomMatch = (a.RoomCount - demands.RoomCount) / demands.RoomCount;
                double SqrMeterMatch = (a.SqrMeter - demands.SqrMeter) / demands.SqrMeter;
                double RentMatch = (demands.Rent - a.Rent) / demands.Rent;
                double ShareableMatch = demands.IsShareable == a.IsShareable ? 1 : 0;
                double BalconyMatch = demands.HasBalcony == a.HasBalcony ? 1 : 0;
                double IsApartmentMatch = demands.IsApartment == a.IsApartment ? 1 : 0;
                double IsHouseMatch = demands.IsHouse == a.IsHouse ? 1 : 0;

                double apartmentScore = petMatch * (roomMatch + SqrMeterMatch + RentMatch + ShareableMatch + BalconyMatch + IsApartmentMatch + IsHouseMatch);

                if (apartmentScore > scoreTreshhold)
                {
                    matches.Add(apartmentScore, a);
                }
            }
            return new List<Apartment>();
        }


        public List<Apartment> GetAll()
        {
            return apartmentRepository.GetApartment();
        }

        public Apartment GetApartment(string ID)
        {
            return apartmentRepository.GetApartmentByID(ID);
        }

        public List<Apartment> GetAllOwnedApartmentsForLandLords(string UserID, string Password)
        {
            if (!userAuth.isLandlord(UserID, Password))
                throw new Exception("ingen privilegier");
            return Context.Apartments.Where(x => x.LandlordID == UserID).ToList();
        }

        public void AddWish(Wishlist wish) {
            apartmentRepository.AddWish(wish);
        }

        public List<WaitingList> GetAllFromWishlist() {
            return apartmentRepository.GetAllFromWishlist();
        }

        public List<WaitingList> GetWishlistById(string UID) {
            return apartmentRepository.GetWishlistById(UID);
        }
    }
}
