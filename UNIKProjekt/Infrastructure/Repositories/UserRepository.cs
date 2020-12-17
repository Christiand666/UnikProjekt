using Domain.Models;
using Domain.Models.Auth;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

        public string GetUserSalt(string Email) {
            if(EmailExists(Email)) {
                User u = GetUsersByEmail(Email);
                return u.Salt;
            } else {
                return null;
            }
        }

        public User SignIn(UserLogin user) {
            var User = Context.Users.Where(x => x.Email == user.Email).Where(x => x.Password == user.Password).FirstOrDefault();

            if(User != null)
                return User;

            return null;
        }

        public bool CheckUserSignedIn(string UserID, string Password) {
            var User = Context.Users.Where(x => x.UserID.Equals(UserID)).Where(x => x.Password.Equals(Password)).FirstOrDefault();

            if(User != null)
                return true;

            return false;
        }

        public bool CheckUserType(string UserID, int UserType) {
            var User = Context.Users.Where(x => x.UserID.Equals(UserID)).Where(x => x.UserType >= UserType).FirstOrDefault();

            if(User != null)
                return true;

            return false;
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
            User userRes = Context.Users.Where(x => x.UserID == ID).FirstOrDefault();
            UserDetails detailsRes = Context.UserDetails.Where(x => x.UserID == ID).FirstOrDefault();

            UserDetails ud = new UserDetails() {
                DetailsID = detailsRes.DetailsID,
                UserID = detailsRes.UserID,
                Phone = detailsRes.Phone,
                Birthdate = detailsRes.Birthdate,
                Address = detailsRes.Address,
                Country = detailsRes.Country,
                Zip = detailsRes.Zip,
                Animals = detailsRes.Animals,
                AnimalType = detailsRes.AnimalType,
                Comment = detailsRes.Comment
            };

            User res = new User() {
                UserDetails = ud,
                Email = userRes.Email,
                Fname = userRes.Fname,
                Lname = userRes.Lname,
                UserID = userRes.UserID,
                UserType = userRes.UserType,
                Password = userRes.Password,
                Salt = userRes.Salt,
            };

            return res;
        }

        public IEnumerable<User> GetUsers()
        {
            return Context.Users.ToList<User>();
        }

        public void Add(User user)
        {
            var CheckUser = EmailExists(user.Email);
            if (CheckUser)
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


        public void Update(User inUser, string UserID, string Password)
        {
            /*var contextusers = Context.Users.Where(x => x.UserID == user.UserID).FirstOrDefault();
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
            contextusers.UserType = user.UserType;
            contextUserDetails.Phone = user.UserDetails.Phone;
            contextUserDetails.Birthdate = user.UserDetails.Birthdate;
            contextUserDetails.Address = user.UserDetails.Address;
            contextUserDetails.Zip = user.UserDetails.Zip;
            contextUserDetails.Country = user.UserDetails.Country;

            Context.SaveChanges();*/

            User usr = Context.Users.Where(x => x.UserID.Equals(inUser.UserID)).FirstOrDefault();

            if(usr != null) {
                User user = new User()
                {
                    UserID = inUser.UserID != null ? inUser.UserID : usr.UserID,
                    Fname = inUser.Fname != null ? inUser.Fname : usr.Fname,
                    Lname = inUser.Lname != null ? inUser.Lname : usr.Lname,
                    Email = inUser.Email != null ? inUser.Email : usr.Email,
                    Password = inUser.Password != null ? inUser.Password : usr.Password,
                    Salt = inUser.Salt != null ? inUser.Salt : usr.Salt,
                    UserType = inUser.UserType != inUser.UserType ? inUser.UserType : usr.UserType,
                };

                //foreach (PropertyInfo item in user.GetType().GetProperties())
                //{
                //    var name = item.Name;

                //    if (item.GetValue(item.GetType(), null) == null)
                //    {
                //        item.SetValue()
                //        //item.SetValue(user, item.GetValue(item.GetType(), null));
                //        //user.GetType();
                //        //User. = item.GetValue(item.GetType(), null);
                //    }
                //}

                Context.Users.Update(user);
                Context.SaveChanges();



            } else {
                throw new Exception("Brugeren kunne ikke findes.");
            }
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
