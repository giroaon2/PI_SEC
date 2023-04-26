using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using PI_SEC.APIs.Controllers;
using PI_SEC.Entities;
using PI_SEC.Interfaces.Services;
using System;
using System.Threading.Tasks;

namespace PI_SECTest.Controllers
{
    public class UserControllerTest
    {
        Mock<IUserServices> mockIUserServices;
        UserController userController;
        [SetUp]
        public void Setup()
        {
            mockIUserServices = new Mock<IUserServices>();
            userController = new UserController(mockIUserServices.Object);
        }

        [Test]
        public async Task When_CreateUser_a_new_once_Return_Id_2()
        {
            mockIUserServices.Setup(u => u.CreateUser(It.IsAny<User>())).Returns(GetId2);
            var result = await userController.CreateUser(GetUserBoy());
            var okResult = result as OkObjectResult;
            var actualValue = okResult.Value;

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, actualValue);
        }

        [Test]
        public async Task When_CreateUser_Throw_Exception()
        {
            mockIUserServices.Setup(u => u.CreateUser(It.IsAny<User>())).Throws(new Exception());
            var result = await userController.CreateUser(GetUserBoy());
            var badResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [Test]
        public async Task When_DeleteUser_a_new_once_Return_True()
        {
            mockIUserServices.Setup(u => u.DeleteUser(It.IsAny<long>())).Returns(GetTrue);
            var result = await userController.DeleteUser(2);
            var okResult = result as OkObjectResult;
            var actualValue = okResult.Value;

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(true, actualValue);
        }

        [Test]
        public async Task When_DeleteUser_Throw_Exception()
        {
            mockIUserServices.Setup(u => u.DeleteUser(It.IsAny<long>())).Throws(new Exception());
            var result = await userController.DeleteUser(1);
            var badResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        [Test]
        public async Task When_UpdateUser_with_newUser_then_return_2()
        {
            User newUser = GetUserBoy();
            mockIUserServices.Setup(u => u.UpdateUser(newUser)).Returns(GetId2);
            var result = await userController.UpdateUser(newUser);
            var okResult = result as OkObjectResult;
            var actualValue = okResult.Value;

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, actualValue);
        }

        [Test]
        public async Task When_UpdateUser_Throw_Exception()
        {
            mockIUserServices.Setup(u => u.UpdateUser(It.IsAny<User>())).Throws(new Exception());
            var result = await userController.UpdateUser(GetUserBoy());
            var badResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.AreEqual(400, badResult.StatusCode);
        }


        [Test]
        public async Task When_GetUser_with_Id_2_then_return_newUser()
        {
            var existUser = GetUserBoyAsync();
            mockIUserServices.Setup(u => u.GetUser(2)).Returns(existUser);
            var result = await userController.GetUserById(2);
            var okResult = result as OkObjectResult;
            var actualValue = okResult.Value as User;

            //Assert
            Assert.IsInstanceOf<OkObjectResult>(result);
            Assert.AreEqual(200, okResult.StatusCode);
            Assert.AreEqual(2, actualValue.Id);
            Assert.AreEqual("Boy", actualValue.UserName);
            Assert.AreEqual("Boy2@gmail.com", actualValue.Email);
        }

        [Test]
        public async Task When_GetUser_Throw_Exception()
        {
            mockIUserServices.Setup(u => u.GetUser(It.IsAny<long>())).Throws(new Exception());
            var result = await userController.GetUserById(2);
            var badResult = result as BadRequestObjectResult;

            //Assert
            Assert.IsInstanceOf<BadRequestObjectResult>(result);
            Assert.AreEqual(400, badResult.StatusCode);
        }

        private User GetUserBoy()
        {
            return new User { Id = 2, UserName = "Boy", Email = "Boy2@gmail.com" };
        }
        private async Task<User> GetUserBoyAsync()
        {
            return GetUserBoy();
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