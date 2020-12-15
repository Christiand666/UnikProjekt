using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Handlers
{
    public interface IApartmentHandler
    {
        void CreateApartment(Apartment apartment);
        void UpdateApartment(Apartment apartment);
        void DeleteApartment(string ID);
        List<Apartment> GetAll();
        Apartment GetApartment(string ID);
    }

    public class ApartmentHandler : IApartmentHandler
    {
        private readonly IApartmentRepository apartmentRepository;

        public ApartmentHandler(IApartmentRepository apartmentRepository)
        {
            this.apartmentRepository = apartmentRepository;
        }
        private readonly IDB Context;

        public void CreateApartment(Apartment apartment)
        {
            try
            {
                apartmentRepository.Add(apartment);
                apartmentRepository.Save();
            }
            catch (Exception e)
            {
                throw e;
                //in da treashcan
            }
        }
        public void UpdateApartment(Apartment apartment)
        {

    
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
                    //in da treashcan
                }
            }
            else
            {
                //apartment your trying to update does not exist//
            }

        }
        public void DeleteApartment(string apartmentID)
        {

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
    }
}
