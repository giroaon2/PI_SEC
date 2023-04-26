using Moq;
using NUnit.Framework;
using PI_SEC.Entities;
using PI_SEC.Interfaces;
using PI_SEC.Services;
using System.Threading.Tasks;

namespace PI_SECTest.Services
{
    public class UserServicesTest
    {
        Mock<IUserRepositories> mockIUserRepositories;
        UserServices userServices;
        [SetUp]
        public void Setup()
        {
            mockIUserRepositories = new Mock<IUserRepositories>();
            userServices = new UserServices(mockIUserRepositories.Object);
        }

        [Test]
        public void When_GetUser_with_Id_1_Return_UserName_Aon()
        {
            mockIUserRepositories.Setup(u => u.Select(It.IsAny<long>())).Returns(GetUserAon);
            var result = userServices.GetUser(1).Result;
            Assert.AreEqual(result.Id, 1);
            Assert.AreEqual(result.UserName, "Aon");
            Assert.AreEqual(result.Email, "giroaon2@gmail.com");
        }

        [Test]
        public void When_CreateUser_a_new_once_Return_Id_2()
        {
            User newUser = new User();
            newUser.UserName = "Boy";
            newUser.Email = "Boy@gmail.com";
            mockIUserRepositories.Setup(u => u.Insert(It.IsAny<User>())).Returns(GetId2);
            var result = userServices.CreateUser(newUser).Result;
            Assert.AreEqual(result, 2);
        }

        [Test]
        public void When_DeleteUser_with_id_1_then_return_true()
        {
            mockIUserRepositories.Setup(u => u.Delete(1)).Returns(GetTrue);
            var result = userServices.DeleteUser(1).Result;
            Assert.AreEqual(result, true);
        }
        [Test]
        public void When_UpdateUser_with_newUser_then_return_2()
        {
            User userBoy = GetUserBoy();
            mockIUserRepositories.Setup(u => u.Update(userBoy)).Returns(GetId2);
            var result = userServices.UpdateUser(userBoy).Result;
            Assert.AreEqual(result, 2);
        }

        private async Task<User> GetUserAon()
        {
            return new User { Id = 1, UserName = "Aon", Email = "giroaon2@gmail.com" };
        }
        private User GetUserBoy()
        {
            return new User { Id = 2, UserName = "Boy", Email = "Boy@gmail.com" };
        }
        private async Task<long> GetId2()
        {
            return 2;
        }
        private async Task<bool> GetTrue()
        {
            return true;
        }
    }
}