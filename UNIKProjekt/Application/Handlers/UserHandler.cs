﻿using Application.Classes;
using Domain.Models;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers
{
    public interface IUserHandler
    {
        void CreateUser(Guid ID, string Fname, string Lname, string Email, string Password, string Phone, DateTime Birthdate, string Address, int Zip, string Country);
        void UpdateUser(Guid ID, string Fname, string Lname, string Email, string Password, string Phone, DateTime Birthdate, string Address, int Zip, string Country);
        void DeleteUsers(Guid ID);
        bool Login(string Email, string Password);
        User GetUsersByID(Guid ID);
    }
    public class UserHandler : IUserHandler
    {
      
        private readonly IUserRepository userRepository;
        private readonly IDB Context;

        public UserHandler(IUserRepository userRepository, IDB Context)
        {
            this.userRepository = userRepository;
            this.Context = Context;
        }

        public void CreateUser(Guid UserID, string Fname, string Lname, string Email, string Password, string Phone, DateTime Birthdate, string Address, int Zip, string Country)
        {
            if (Fname == "" || Lname == "" || Email == "" || Password == "" || Phone == "" || Birthdate == null || Address == "" || Convert.ToString(Zip) == "" || Country == "")
                throw new Exception("nogen felter er ikke udfyldt");

            User users = new User();
            UserDetails ud = new UserDetails();
            users.UserID = UserID; //HER
            users.Fname = Fname;
            users.Lname = Lname;
            users.Email = Email;
            users.Password = Password;
            ud.Phone = Phone;
            ud.Birthdate = Birthdate;
            ud.Address = Address;
            ud.Zip = Zip;
            ud.Country = Country;

            try
            {
                //using (transactionscope scoped = new transactionscope())
                //{
                //    context.users.add(users);
                //    context.savechanges();
                //    context.ud.add(ud);
                //    context.savechanges();
                //}
                userRepository.Add(users, ud);
                userRepository.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public void UpdateUser(Guid UserID, string Fname, string Lname, string Email, string Password, string Phone, DateTime Birthdate, string Address, int Zip, string Country)
        {
            User users = new User();
            UserDetails ud = new UserDetails();
            users.UserID = UserID; //HER
            users.Fname = Fname;
            users.Lname = Lname;
            users.Email = Email;
            users.Password = Password;
            ud.Phone = Phone;
            ud.Birthdate = Birthdate;
            ud.Address = Address;
            ud.Zip = Zip;
            ud.Country = Country;

            try
            {
                userRepository.Add(users, ud);
                userRepository.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public User GetUsersByID(Guid ID)
        {
            return userRepository.GetUsersByID(ID);
        }

        //delete user ved faktisk ikke helt om man selv skulle slette sin profil eller om admin skal kun kunne gøre det eller den dummy liste over inaktive

        public void DeleteUsers(Guid UserID)
        {
            //mangler noget admin slette elelr om de skal achvies
            User user = userRepository.GetUsersByID(UserID);
            userRepository.Delete(user);
            userRepository.Save();

        }
        public void ToggleUserActivity(Guid UserID, Guid AdminID)
        {
            //WIP//
            /*Users user= userRepository.GetUsersByID(UsersID);
            user.activity = !user.activity;
            userRepository.Update(user);
            userRepository.Save();
            */

        }

        public bool Login(string Email, string Password)
        {
            if (string.IsNullOrEmpty(Email) && string.IsNullOrEmpty(Password))
            {
                throw new Exception("Udfyld alle felter!");
            }
            else
            {
                string mail = Email.Trim(); // Removes whitespace before and after text.
                //string pwd = Hashing.Hash(Password);

                //var user = Context.Users.Where(x => x.Email == mail && x.Password == pwd).FirstOrDefault();
                Context.SaveChanges();

                //if (user != null) return true;
            }

            return false;
        }

        public bool UserAuthorize(Guid UserID, int UserType)
        {
            try
            {
                var userAuth = Context.Users.Where(x => x.UserID == UserID && x.UserType == UserType).FirstOrDefault();

                if (userAuth != null)
                    return true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        public void ChageUserType(Guid UserID, int UserType)
        {
            if (!UserAuthorize(UserID, UserType)) throw new Exception("Adgang nægtet!");

            try
            {
                var user = Context.Users.Where(x => x.UserID == UserID).FirstOrDefault();

                user.UserType = UserType;

                Context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void CreateOrUpdateDetails(UserDetails details)
        {
            /*UserDetails user = new UserDetails();
            if (details == null)
            {
                details.DetailID = Guid.NewGuid();
                Context.UserDetails.Add(details);
            }
            else
            {
                user.aboutyourself = details.aboutyourself;
                user.Pet = details.Pet;
                user.Dog = details.Dog;
                user.Cat = details.Cat;
                user.Other = details.Other;
                user.WhatPet = details.WhatPet;

                userRepository.CreateUpdateUserDetails(user);
                userRepository.Save();
            }*/

            //Context.SaveChanges();
        }
    }
}
