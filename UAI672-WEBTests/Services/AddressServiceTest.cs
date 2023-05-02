using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAI672_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;

namespace UAI672_WEB.Services.Tests
{

    [TestClass()]
    public class AddressServiceTests
    {
        private AddressService _addressService;
        private Mock<IRepository<Addresses>> _addressRepositoryMock;

        [TestInitialize]
        public void Setup()
        {
            // Arrange
            _addressRepositoryMock = new Mock<IRepository<Addresses>>();
            _addressService = new AddressService(_addressRepositoryMock.Object);
        }

        [TestMethod()]
        public void AddressServiceTest()
        {
            // Act
            var addressService = new AddressService(_addressRepositoryMock.Object);

            // Assert
            Assert.IsNotNull(addressService);
            Assert.IsNotNull(addressService.Get());
            Assert.AreEqual(_addressRepositoryMock.Object, addressService.Get());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 20, City = "City1" };
            _addressRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).Returns(address);

            // Act
            var result = _addressService.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(address.Id, result.Id);
            Assert.AreEqual(address.Number, result.Number);
            Assert.AreEqual(address.City, result.City);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 20, City = "City1" };

            // Act
            _addressService.Add(address);

            // Assert
            _addressRepositoryMock.Verify(repo => repo.AddAsync(address), Times.Once());
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 20, City = "City1" };

            // Act
            _addressService.Update(address);

            // Assert
            _addressRepositoryMock.Verify(repo => repo.UpdateAsync(address), Times.Once());
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            int id = 1;

            // Act
            _addressService.Delete(id);

            // Assert
            _addressRepositoryMock.Verify(repo => repo.DeleteAsync(id), Times.Once());

        }
       
    }

}
