using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IDB Context;
        private bool IsItDisposed = false;

        public UserRepository(IDB dB)
        {
            this.Context = dB;
        }

        public User GetUsersByEmail(string Email)
        {
            var Users = Context.Users.Where(x => x.Email == Email).FirstOrDefault();
            return Users;
        }

        public bool EmailExists(string Email)
        {

            var usr = Context.Users.Any(x => x.Email == Email);

            if (usr)
                return true;

            return false;
        }

        public User GetUsersByID(string ID)
        {
            return Context.Users.Where(x => x.UserID == ID.ToString()).FirstOrDefault(); // HER
        }

        public IEnumerable<User> GetUsers()
        {
            return Context.Users.ToList<User>();
        }

        public void Add(User user)
        {
            var CheckUser = this.Context.Users.Where(x => x.Email == user.Email || x.UserID.Equals(Context.UserDetails.Where(s => s.Phone == user.UserDetails.Phone).FirstOrDefault().UserID)).FirstOrDefault();
            if (CheckUser != null)
                throw new Exception("Brugeren eksistere allerede, Login eller tryk glemt kodeord");

            Context.Users.Add(user);
            Context.SaveChanges();

        }

        public void Delete(User users)
        {
            var CheckUser = this.Context.Users.Where(x => x.Email == users.Email).FirstOrDefault();
            if (CheckUser == null)
                throw new Exception("Brugeren blev ikke fundet check om det er de rigtige kreterier");

            Context.Users.Remove(users);
        }


        public void Update(User user)
        {
            var contextusers = Context.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
            var contextUserDetails = Context.UserDetails.Where(x => x.UserID.Equals(user.UserID)).FirstOrDefault();
            if (contextusers == null)
                throw new Exception("brugeren blev ikke fundet");

            if (Context.Users.Any(x => x.Email == user.Email)) throw new Exception("Emailen er allerede taget i brug");
            //var EmailExsist = Context.Users.Where(x => x.Email == users.Email).ToList();
            //if (EmailExsist.Count() > 0)
            //{
            //    if(EmailExsist[0] !=contextusers)
            //    throw new Exception("Emailen er allerede taget i brug");
            //}
            if (Context.UserDetails.Any(x => x.Phone == user.UserDetails.Phone))
                throw new Exception("Telefonummeret er allerede taget i brug");

            //var PhoneExsist = Context.Users.Where(x => x.Phone == users.Phone).ToList();
            //if (PhoneExsist.Count() > 0)
            //{
            //    if (PhoneExsist[0] != contextusers)
            //        throw new Exception("Telefonummeret er allerede taget i brug");
            //}

            contextusers.Fname = user.Fname;
            contextusers.Lname = user.Lname;
            contextusers.Email = user.Email;
            contextUserDetails.Phone = user.UserDetails.Phone;
            contextUserDetails.Birthdate = user.UserDetails.Birthdate;
            contextUserDetails.Address = user.UserDetails.Address;
            contextUserDetails.Zip = user.UserDetails.Zip;
            contextUserDetails.Country = user.UserDetails.Country;


        }

        public void CreateUpdateUserDetails(UserDetails details)
        {
            var User = Context.Users.Where(x => x.UserID.Equals(details.UserID)).FirstOrDefault();
            if (User == null)
                throw new Exception("User not found");

            var _Details = Context.UserDetails.Where(x => x.UserID == details.UserID).FirstOrDefault();

        }

        public void Save()
        {
            Context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.IsItDisposed)
            {
                if (disposing)
                {
                    Context.Dispose();
                }
            }
            this.IsItDisposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
