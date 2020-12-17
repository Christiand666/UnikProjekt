using Application.Handlers;
using Domain.Models;
using Moq;
using Xunit;

namespace UnitTests
{
    public class TestTests
    {

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

        [Fact]
        public void Test_CreateNewUser_DoesAlreadyExistInDatabase()
        {
            User user = User.CreateNewUser("Tester", "Testerson", "Tester@testerson.com", "123pw", "saltsaltsaltsalt");

            var mock = new Mock<IUserHandler>();
            mock.Setup(x => x.DoesAlreadyExistInDatabase()).Returns(true);

            Assert.Equal("Tester", user.Fname);
            Assert.Equal("Testerson", user.Lname);
            Assert.Equal("Tester@testerson.com", user.Email);
            Assert.Equal("123pw", user.Password);
            Assert.Equal("saltsaltsaltsalt", user.Salt);
        }
    }
}
