using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAI672_WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;

namespace UAI672_WEB.Models.Tests
{
    [TestClass()]
    public class AddressRepositoryTests
    {
        private Mock<Model1> _db;
        private AddressRepository _addressRepository;

        [TestInitialize]
        public void Setup()
        {
            _db = new Mock<Model1>(); 
            _addressRepository = new AddressRepository(_db.Object);
        }
        [TestMethod()]
        public void AddressRepositoryTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetAllTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            // Přidání testovacího adresy do databáze
            var address = new Addresses { Id = 1, Number = 2, City = "Test City" };
            _db.Object.Addresses.Add(address);
            _db.Object.SaveChanges();

            // Act
            var result = _addressRepository.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test Street", result.Number);
            Assert.AreEqual("Test City", result.City);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var address = new Addresses { Id = 1,  Number = 2, City = "Test City" };

            // Act
            _addressRepository.Add(address);

            // Assert
            var result = _db.Object.Addresses.Find(1);
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual("Test Street", result.Number);
            Assert.AreEqual("Test City", result.City);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            // Přidání testovacího adresy do databáze
            var address = new Addresses { Id = 1, Number = 2, City = "Test City" };
            _db.Object.Addresses.Add(address);
            _db.Object.SaveChanges();

            // Aktualizace adresy
            address.Number = 2;
            address.City = "Updated City";

            // Act
            _addressRepository.Update(address);

            // Assert
            var result = _db.Object.Addresses.Find(1);
            Assert.IsNotNull(result);
            Assert.AreEqual("Updated Street", result.Number);
            Assert.AreEqual("Updated City", result.City);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            // Přidání testovacího adresy do databáze
            var address = new Addresses { Id = 1, Number = 2, City = "Test City" };
            _db.Object.Addresses.Add(address);
            _db.Object.SaveChanges();
            // Act
            _addressRepository.Delete(1);

            // Assert
            var result = _db.Object.Addresses.Find(1);
            Assert.IsNull(result);
        }
    }
}