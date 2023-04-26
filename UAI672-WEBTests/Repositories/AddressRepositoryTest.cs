using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Repositories.Tests
{
    [TestClass]
    public class AddressRepositoryTests
    {
        private Mock<Model1> dbMock;
        private AddressRepository addressRepository;

        [TestInitialize]
        public void Setup()
        {
            // Vytvoření mocku pro DbContext
            dbMock = new Mock<Model1>();

            // Vytvoření instance AddressRepository s použitím mocku pro DbContext
            addressRepository = new AddressRepository(dbMock.Object);
        }

        [TestMethod]
        public void GetAllTestS()
        {
            // Arrange
            var addresses = new List<Addresses>
            {
                new Addresses { Id = 1, Number = 3, City = "City1" },
                new Addresses { Id = 2, Number = 6, City = "City2" },
                new Addresses { Id = 3, Number = 9, City = "City3" }
            }.AsQueryable();

            var addressesSetMock = new Mock<DbSet<Addresses>>();
            addressesSetMock.As<IQueryable<Addresses>>().Setup(m => m.Provider).Returns(addresses.Provider);
            addressesSetMock.As<IQueryable<Addresses>>().Setup(m => m.Expression).Returns(addresses.Expression);
            addressesSetMock.As<IQueryable<Addresses>>().Setup(m => m.ElementType).Returns(addresses.ElementType);
            addressesSetMock.As<IQueryable<Addresses>>().Setup(m => m.GetEnumerator()).Returns(() => addresses.GetEnumerator());

            dbMock.Setup(db => db.Addresses).Returns(addressesSetMock.Object);

            // Act
            var result = addressRepository.GetAll();

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void GetByIdTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 25, City = "City1" };
            dbMock.Setup(db => db.Addresses.Find(1)).Returns(address);

            // Act
            var result = addressRepository.GetById(1);

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(25, result.Number);
            Assert.AreEqual("City1", result.City);
        }

        [TestMethod]
        public void AddTest()
        {
            // Arrange
            Addresses address = new Addresses { Id = 1, Number = 25, City = "City1" };

            // Act
            addressRepository.Add(address);

            // Assert
            dbMock.Verify(db => db.Addresses.Add(address), Times.Once);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void UpdateTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 454, City = "City1" };

            // Act
            addressRepository.Update(address);

            // Assert
            dbMock.Verify(db => db.Addresses.Remove(address), Times.Never);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
            dbMock.Verify(db => db.Entry(address).State.Equals( EntityState.Modified), Times.Once);
        }

        [TestMethod]
        public void DeleteTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 3, City = "City1" };
            dbMock.Setup(db => db.Addresses.Find(1)).Returns(address);

            // Act
            addressRepository.Delete(1);

            // Assert
            dbMock.Verify(db => db.Addresses.Remove(address), Times.Once);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
