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

        public User GetUsersByID(Guid ID)
        {
            return Context.Users.Where(x => x.UserID == ID).FirstOrDefault(); // HER
        }

        public IEnumerable<User> GetUsers()
        {
            return Context.Users.ToList<User>();
        }

        public void Add(User users, UserDetails ud)
        {
            var CheckUser = this.Context.Users.Where(x => x.Email == users.Email || x.UserID.Equals(Context.UserDetails.Where(s => s.Phone == ud.Phone).FirstOrDefault().UserID)).FirstOrDefault();
            if (CheckUser != null)
                throw new Exception("Brugeren eksistere allerede, Login eller tryk glemt kodeord");

            Context.Users.Add(users);
            Context.SaveChanges();

        }

        public void Delete(User users)
        {
            var CheckUser = this.Context.Users.Where(x => x.Email == users.Email).FirstOrDefault();
            if (CheckUser == null)
                throw new Exception("Brugeren blev ikke fundet check om det er de rigtige kreterier");

            Context.Users.Remove(users);
        }


        public void Update(User users, UserDetails ud)
        {
            var contextusers = Context.Users.Where(x => x.UserID == users.UserID).FirstOrDefault();
            var contextUserDetails = Context.UserDetails.Where(x => x.UserID.Equals(users.UserID)).FirstOrDefault();
            if (contextusers == null)
                throw new Exception("brugeren blev ikke fundet");

            if (Context.Users.Any(x => x.Email == users.Email)) throw new Exception("Emailen er allerede taget i brug");
            //var EmailExsist = Context.Users.Where(x => x.Email == users.Email).ToList();
            //if (EmailExsist.Count() > 0)
            //{
            //    if(EmailExsist[0] !=contextusers)
            //    throw new Exception("Emailen er allerede taget i brug");
            //}
            if (Context.UserDetails.Any(x => x.Phone == ud.Phone))
                throw new Exception("Telefonummeret er allerede taget i brug");

            //var PhoneExsist = Context.Users.Where(x => x.Phone == users.Phone).ToList();
            //if (PhoneExsist.Count() > 0)
            //{
            //    if (PhoneExsist[0] != contextusers)
            //        throw new Exception("Telefonummeret er allerede taget i brug");
            //}

            contextusers.Fname = users.Fname;
            contextusers.Lname = users.Lname;
            contextusers.Email = users.Email;
            contextUserDetails.Phone = ud.Phone;
            contextUserDetails.Birthdate = ud.Birthdate;
            contextUserDetails.Address = ud.Address;
            contextUserDetails.Zip = ud.Zip;
            contextUserDetails.Country = ud.Country;


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
