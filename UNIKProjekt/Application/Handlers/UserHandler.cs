﻿using Application.Classes;
using Domain.Models;
using Domain.Models.Auth;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Handlers
{
    public interface IUserHandler
    {
        string GetUserSalt(UserLogin user);
        User SignIn(UserLogin user);
        bool CheckUserSignedIn(string UserID, string Password);
        void CreateUser(User user);
        void UpdateUser(User user, string UserID, string Password);
        void DeleteUsers(string ID);
        bool Login(string Email, string Password);
        User GetUsersByID(string ID);
        List<User> GetAllUsers();

        //bool til test af User
        bool DoesAlreadyExistInDatabase();
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

        public string GetUserSalt(UserLogin user) {
            return userRepository.GetUserSalt(user.Email);
        }

        public User SignIn(UserLogin user) {
            return userRepository.SignIn(user);
        }

        public bool CheckUserSignedIn(string UserID, string Password) {
            if(userRepository.CheckUserSignedIn(UserID, Password))
                return true;

            return false;
        }

        public void CreateUser(User user)
        {
            if (IsNotEmpty(user))
            {
                try
                {
                    //using (transactionscope scoped = new transactionscope())
                    //{
                    //    context.users.add(users);
                    //    context.savechanges();
                    //    context.ud.add(ud);
                    //    context.savechanges();
                    //}

                    userRepository.Add(user);
                    userRepository.Save();
                }
                catch (Exception e)
                {
                   throw e;
                }
            }

            
        }
        public void UpdateUser(User user, string UserID, string Password)
        {
            //if (IsNotEmpty(user))
            {
            try
                {
                    userRepository.Update(user, UserID, Password);
                    //userRepository.Save();
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
            //
        }
        public User GetUsersByID(string ID)
        {
            return userRepository.GetUsersByID(ID);
        }
        public List<User> GetAllUsers()
        {
            return userRepository.GetUsers().ToList();
        }
        //delete user ved faktisk ikke helt om man selv skulle slette sin profil eller om admin skal kun kunne gøre det eller den dummy liste over inaktive

        public void DeleteUsers(string UserID)
        {
            //mangler noget admin slette elelr om de skal achvies
            // User user = userRepository.GetUsersByID(UserID);
            // userRepository.Delete(user);
            // userRepository.Save();

        }
        public void ToggleUserActivity(string UserID, string AdminID)
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

        public bool UserAuthorize(string UserID, int UserType)
        {
            try
            {
                var userAuth = Context.Users.Where(x => x.UserID == UserID.ToString() && x.UserType == UserType).FirstOrDefault();

                if (userAuth != null)
                    return true;
            }
            catch (Exception e)
            {
                throw e;
            }

            return false;
        }

        public void ChageUserType(string UserID, int UserType)
        {
            if (!UserAuthorize(UserID, UserType)) throw new Exception("Adgang nægtet!");

            try
            {
                var user = Context.Users.Where(x => x.UserID == UserID.ToString()).FirstOrDefault();

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
        private bool IsNotEmpty(User user)
        {
            if (user.Fname == "" || user.Lname == "" || user.Email == "" || user.Password == "" || user.UserDetails.Phone == "" || user.UserDetails.Birthdate == null || user.UserDetails.Address == "" || Convert.ToString(user.UserDetails.Zip) == "" || user.UserDetails.Country == "")
                return false;
            else
                return true;
        }

        //bool til test af User
        public bool DoesAlreadyExistInDatabase()
        {
            return true;
        }
    }
}
