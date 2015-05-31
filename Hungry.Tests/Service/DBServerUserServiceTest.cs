using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Hungry.Repository.Interfaces;
using Hungry.Service.Interfaces;
using Hungry.Repository.Generics;
using System.Collections.Generic;
using Hungry.Model;
using Hungry.Service;

namespace Hungry.Tests.Service
{
    [TestClass]
    public class DBServerUserServiceTest
    {
        private Mock<IDBServerUserRepository> _mockRepository;
        private IDBServerUserService _service;
        Mock<IUnitOfWork> _mockUnitWork;
        List<DBServerUser> listObject;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IDBServerUserRepository>();
            _mockUnitWork = new Mock<IUnitOfWork>();
            _service = new DBServerUserService(_mockUnitWork.Object, _mockRepository.Object);
            listObject = new List<DBServerUser>() {
                new DBServerUser() { Id = 1, Username = "andrew" },
                new DBServerUser() { Id = 2, Username = "lucas" },
                new DBServerUser() { Id = 3, Username = "wagner" }
            };
        }

        [TestMethod]
        public void DBServerUser_Get_All()
        {
            //Arrange
            _mockRepository.Setup(x => x.GetAll()).Returns(listObject);

            //Act
            List<DBServerUser> results = _service.GetAll() as List<DBServerUser>;

            //Assert
            Assert.IsNotNull(results);
            Assert.AreEqual(3, results.Count);
        }

        [TestMethod]
        public void Can_Add_DBServerUser()
        {
            //Arrange
            int Id = 1;
            DBServerUser emp = new DBServerUser() { Username = "andrew" };
            _mockRepository.Setup(m => m.Add(emp)).Returns((DBServerUser e) =>
            {
                e.Id = Id;
                return e;
            });


            //Act
            _service.Create(emp);

            //Assert
            Assert.AreEqual(Id, emp.Id);
            _mockUnitWork.Verify(m => m.Commit(), Times.Once);
        }
    }
}
