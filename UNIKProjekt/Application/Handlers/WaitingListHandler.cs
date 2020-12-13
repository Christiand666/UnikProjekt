using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.Models;
using Infrastructure.Interface;

namespace Application.Handlers
{
    public interface IWaitingListPrio
    {
        void Create(WaitingList list);
        List<Apartment> GetAllWaitingLists(string UserID);

        void Remove(string userID, string EstateID);
    }
    class WaitingListHandler : IWaitingListPrio
    {
        private readonly IDB Context;
        private readonly IUserHandler userHandler;
        private readonly IApartmentRepository apartmentRepository;

        public WaitingListHandler(IApartmentRepository ApartmentRepository, IDB context)
        {
            Context = context;
            apartmentRepository = ApartmentRepository;
        }

        public void Create(WaitingList list)
        {
            list.WaitingID = Guid.NewGuid().ToString();

            var User = Context.Users.Where(x => x.UserID == list.UserID.ToString()).FirstOrDefault();
            if (User == null)
                throw new Exception("Brugeren blev ikke fundet");

            var Apartment = Context.Apartments.Where(x => x.ApartmentID == list.ApartmentID.ToString()).FirstOrDefault();
            if (Apartment == null)
                throw new Exception("Apartment not found");

            Context.WaitingList.Add(list);
            Context.SaveChanges();

        }

        public void Remove(string UserID, string ApartmentID)
        {
            var WaitingGoup = Context.WaitingList.Where(x => x.UserID == UserID && x.ApartmentID == ApartmentID).FirstOrDefault();
            Context.WaitingList.Remove(WaitingGoup);
            Context.SaveChanges();
        }

        public List<Apartment> GetAllWaitingLists(string UserID)
        {
            List<WaitingList> lists = Context.WaitingList.Where(x => x.UserID == UserID.ToString()).ToList();

            List<Apartment> AllAparmentsWritenUp = new List<Apartment>();
            foreach (var list in lists)
            {
                var x = Context.Apartments.Where(x => x.ApartmentID == list.ApartmentID.ToString()).FirstOrDefault();

                if (x != null)
                    AllAparmentsWritenUp.Add(x);
            }

            return AllAparmentsWritenUp;
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
                double ShareableMatch = demands.Shareable == a.IsShareable ? 1 : 0;
                double BalconyMatch = demands.Balcony == a.Balcony ? 1 : 0;
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
    }
}
