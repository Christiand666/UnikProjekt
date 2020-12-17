using Application.Handlers;
using Domain.Models;
using Infrastructure.Repositories;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Xunit;

namespace UnitTests
{
    public class TestTests
    {
        

        //should receive an exception, because the name is an empty string.
        [Fact]
        //[ExpectedException(typeof(ArgumentException))]
        public void Test_CreateNewUser_EmptyName()
        {
            User user = User.CreateNewUser("", "Testerson", "Tester@testerson.com", "123pw", "saltsaltsaltsalt");

            var mock = new Mock<IUserHandler>();
            mock.SetupAdd(x => x.CreateUser(user));

            Assert.Throws<ArgumentException>(() => user.Fname);
        }

        //Should also receive an exception, because the user already exists.
        //[Fact]
        ////[ExpectedException(typeof(ArgumentException))]
        //public void Test_CreateNewUser_AlreadyExistsInDatabase()
        //{
        //    User user = User.CreateNewUser("Tester", "Testerson", "Tester@testerson.com", "123pw", "saltsaltsaltsalt");
        //    var mock = new Mock<IUserHandler>();
        //    mock.Setup(x => x.DoesAlreadyExistInDatabase()).Returns(true);

        //    Assert.Throws<ArgumentException>

        //}

        [Fact]
        public void Test_CreateNewUser_DoesNotAlreadyExistInDatabase()
        {
            User user = User.CreateNewUser("Tester", "Testerson", "Tester@testerson.com", "123pw", "saltsaltsaltsalt");

            var mock = new Mock<IUserHandler>();
            mock.Setup(x => x.DoesAlreadyExistInDatabase()).Returns(false);

            Assert.Equal("Tester", user.Fname);
            Assert.Equal("Testerson", user.Lname);
            Assert.Equal("Tester@testerson.com", user.Email);
            Assert.Equal("123pw", user.Password);
            Assert.Equal("saltsaltsaltsalt", user.Salt);
        }
        
        
        //[TestMethod]
        //[ExpectedException(typeof(ArgumentException))]


        //[Fact]
        //public void PassingTest()
        //{
        //}
        //[Fact]
        //public void FailingTest()
        //{
        //    Assert.Equal(5, Add(3, 2));
        //}
        //int Add(int x, int y)
        //{
        //    return x + y;
        //}
    }
}
