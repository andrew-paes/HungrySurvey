using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Hungry.Service.Interfaces;
using System.Collections.Generic;
using Hungry.Model;
using HungrySurvey.Controllers;

namespace Hungry.Tests.Controller
{
    [TestClass]
    public class DBServerUserControllerTest
    {
        private Mock<IDBServerUserService> _dbServerUserServiceMock;
        DBServerUserController objController;
        List<DBServerUser> listDBServerUser;

        [TestInitialize]
        public void Initialize()
        {
            _dbServerUserServiceMock = new Mock<IDBServerUserService>();
            objController = new DBServerUserController(_dbServerUserServiceMock.Object);
            listDBServerUser = new List<DBServerUser>() {
           new DBServerUser() { Id = 1, Username = "andrew" },
           new DBServerUser() { Id = 2, Username = "lucas" },
           new DBServerUser() { Id = 3, Username = "wagner" }
          };
        }

        [TestMethod]
        public void DBServerUser_Get_All()
        {
        }
    }
}
