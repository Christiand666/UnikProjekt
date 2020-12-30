using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Application.Classes;
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
    public class WaitingListHandler : IWaitingListPrio
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
            var User = Context.UserDetails.Where(x => x.UserID == list.UserID).FirstOrDefault();
            if (User == null)
                throw new Exception("Brugeren blev ikke fundet");

            var Apartment = Context.Apartments.Where(x => x.ApartmentID == list.ApartmentID).FirstOrDefault();
            if (Apartment == null)
                throw new Exception("Apartment not found");

            var Goals = Context.ApplicantGoals.Where(x => x.GoalsID == Apartment.ApplicantGoalsID).FirstOrDefault();
            if (Goals == null)
                throw new Exception("Du kan ikke skrive dig op til dette lejemål.");

            WaitingList newWL = new WaitingList()
            {
                WaitingID = Guid.NewGuid().ToString(),
                UserID = list.UserID,
                ApartmentID = list.ApartmentID,
                ApplicationScore = ScoreApplication(Goals, User)
            };

            Context.WaitingList.Add(newWL);
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

        public double ScoreApplication(ApplicantGoals goals, UserDetails user)
        {
            int TargetAge = DateTime.Now.Year - goals.Birthdate.Year;
            if (DateTime.Now.DayOfYear < goals.Birthdate.DayOfYear)
            {
                TargetAge = TargetAge - 1;
            }

            int AgeOfApplicant = DateTime.Now.Year - user.Birthdate.Year;
            if (DateTime.Now.DayOfYear < user.Birthdate.DayOfYear)
            {
                AgeOfApplicant = AgeOfApplicant - 1;
            }

            //Remember to add factors here
            int petMatch = user.Animals ? Convert.ToInt32(goals.Animals) : 1;
            double ageMatch = Math.Min(1 - (Math.Abs(AgeOfApplicant - TargetAge)) / TargetAge, 0.3);
            double hasComment = user.Comment != null ? 1.3 : 1;

            return petMatch * (ageMatch + hasComment);
        }
    }
}
