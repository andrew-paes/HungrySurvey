using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Hungry.Service.Interfaces;
using HungrySurvey.Controllers;
using System.Collections.Generic;
using Hungry.Model;
using System.Web.Mvc;

namespace Hungry.Tests.Controllers
{
    [TestClass]
    public class DBServerUserControllerTest
    {
        private Mock<IDBServerUserService> _serviceMock;
        DBServerUserController objController;
        List<DBServerUser> listObjject;

        [TestInitialize]
        public void Initialize()
        {
            _serviceMock = new Mock<IDBServerUserService>();
            objController = new DBServerUserController(_serviceMock.Object);

            listObjject = new List<DBServerUser>() {
                new DBServerUser() { Id = 1, Username = "andrew" }
                ,new DBServerUser() { Id = 2, Username = "lucas" }
                ,new DBServerUser() { Id = 3, Username = "wagner" }
            };
        }

        [TestMethod]
        public void DBServerUser_Get_All()
        {
            //Arrange
            _serviceMock.Setup(x => x.GetAll()).Returns(listObjject);

            //Act
            var result = ((objController.Index() as ViewResult).Model) as List<DBServerUser>;

            //Assert
            Assert.AreEqual(result.Count, 3);
            Assert.AreEqual("andrew", result[0].Username);
            Assert.AreEqual("lucas", result[1].Username);
            Assert.AreEqual("wagner", result[2].Username);
        }

        [TestMethod]
        public void Valid_DBServerUser_Create()
        {
            //Arrange
            DBServerUser x = new DBServerUser() { Username = "usuario1" };

            //Act
            var result = (RedirectToRouteResult)objController.Create(x);

            //Assert 
            _serviceMock.Verify(m => m.Create(x), Times.Once);

            Assert.AreEqual("Index", result.RouteValues["action"]);

        }

        [TestMethod]
        public void Invalid_DBServerUser_Create()
        {
            // Arrange
            DBServerUser c = new DBServerUser() { Username = "" };
            objController.ModelState.AddModelError("Error", "Usuário não inserido");

            //Act
            var result = (ViewResult)objController.Create(c);

            //Assert
            _serviceMock.Verify(m => m.Create(c), Times.Never);
            Assert.AreEqual("", result.ViewName);
        }
    }
}
