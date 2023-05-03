using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
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
        public async Task GetAllAsyncTestS()
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
            var result = await addressRepository.GetAllAsync();

            // Assert
            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public async Task GetByIdAsyncTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 25, City = "City1" };
            dbMock.Setup(db => db.Addresses.FindAsync(1)).ReturnsAsync(address);

            // Act
            var result = await addressRepository.GetByIdAsync(1);

            // Assert
            Assert.AreEqual(1, result.Id);
            Assert.AreEqual(25, result.Number);
            Assert.AreEqual("City1", result.City);
        }

        [TestMethod]
        public async Task AddAsyncTest()
        {
            // Arrange
            Addresses address = new Addresses { Id = 1, Number = 25, City = "City1" };

            // Act
            await addressRepository.AddAsync(address);

            // Assert
            dbMock.Verify(db => db.Addresses.Add(address), Times.Once);
            dbMock.Verify(db => db.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task UpdateAsyncTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 454, City = "City1" };

            // Act
            await addressRepository.UpdateAsync(address);

            // Assert
            dbMock.Verify(db => db.Entry(address).State.Equals( EntityState.Modified), Times.Once);
            dbMock.Verify(db => db.SaveChangesAsync(), Times.Once);
        }

        [TestMethod]
        public async Task DeleteTest()
        {
            // Arrange
            var address = new Addresses { Id = 1, Number = 3, City = "City1" };
            dbMock.Setup(db => db.Addresses.FindAsync(1)).ReturnsAsync(address);

            // Act
            await addressRepository.DeleteAsync(1);

            // Assert
            dbMock.Verify(db => db.Addresses.Remove(address), Times.Once);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}
