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
            list.WaitingID = Guid.NewGuid().ToString();

            var User = Context.Users.Where(x => x.UserID == list.UserID.ToString()).FirstOrDefault();
            if (User == null)
                throw new Exception("Brugeren blev ikke fundet");

            var Apartment = Context.Apartments.Where(x => x.ApartmentID == list.ApartmentID.ToString()).FirstOrDefault();
            if (Apartment == null)
                throw new Exception("Apartment not found");

            list.ApplicationScore = ScoreApplication(Apartment.ApplicantGoals, User);
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

        public double ScoreApplication(ApplicantGoals goals, User user)
        {
            Age AgeOfApplicant = new Age(user.UserDetails.Birthdate);
            Age TargetAge = new Age(goals.Birthdate);
            //Remember to add factors here
            int petMatch = user.UserDetails.Animals ? Convert.ToInt32(goals.Animals) : 1;
            double ageMatch = (Math.Abs(AgeOfApplicant.Value - TargetAge.Value)) / TargetAge.Value;
            double hasComment = user.UserDetails.Comment != null ? 1.3 : 1;

            return petMatch * ageMatch * hasComment;
        }
    }
}
