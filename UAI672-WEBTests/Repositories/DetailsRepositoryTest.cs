using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAI672_WEB.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using UAI672_WEB.Models;
using System.Data.Entity;

namespace UAI672_WEB.Repositories.Tests
{
    [TestClass()]
    public class DetailsRepositoryTests
    {
        private Mock<Model1> dbMock;
        private DetailsRepository detailsRepository;

        [TestInitialize]
        public void Setup()
        {
            // Initialize the Model1 mock
            dbMock = new Mock<Model1>();

            // Create an instance of DetailsRepository using the Model1 mock
            detailsRepository = new DetailsRepository(dbMock.Object);
        }

        [TestMethod()]
        public void DetailsRepositoryTest()
        {
            // Assert
            Assert.IsNotNull(detailsRepository);
            Assert.AreEqual(dbMock.Object, detailsRepository.Get());
        }

        [TestMethod()]
        public async Task GetAllTestAsync()
        {
            // Arrange
            var details = new List<Details>
            {
                new Details { ID = 1, Name = "Detail1", Surname = "Surname1" },
                new Details { ID = 2, Name = "Detail2", Surname = "Surname2" },
                new Details { ID = 3, Name = "Detail3", Surname = "Surname3" }
            };
            dbMock.Setup(db => db.Details.ToListAsync()).ReturnsAsync(details);

            // Act
            var result = await detailsRepository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(details.Count, result.Count());
            CollectionAssert.AreEqual(details, result.ToList());
        }

        [TestMethod()]
        public async Task GetByIdTestAsync()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            dbMock.Setup(db => db.Details.FindAsync(1)).ReturnsAsync(detail);

            // Act
            var result = await detailsRepository.GetByIdAsync(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(detail, result);
        }

        [TestMethod()]
        public async Task AddTestAsync()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            var detailsSetMock = new Mock<DbSet<Details>>();
            dbMock.Setup(db => db.Details).Returns(detailsSetMock.Object);

            // Act
            await detailsRepository.AddAsync(detail);

            // Assert
            detailsSetMock.Verify(set => set.Add(detail), Times.Once);
            dbMock.Verify(db => db.SaveChangesAsync(), Times.Once);
        }

        [TestMethod()]
        public async Task UpdateTestAsync()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            var detailsSetMock = new Mock<DbSet<Details>>();
            dbMock.Setup(db => db.Details).Returns(detailsSetMock.Object);

            // Act
            await detailsRepository.UpdateAsync(detail);

            // Assert
            detailsSetMock.Verify(set => set.Attach(detail), Times.Once);
            dbMock.Verify(db => db.SaveChangesAsync(), Times.Once);
        }

        [TestMethod()]
        public async Task DeleteTestAsync()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            var detailsSetMock = new Mock<DbSet<Details>>();
            detailsSetMock.Setup(set => set.Remove(detail));
            dbMock.Setup(db => db.Details).Returns(detailsSetMock.Object);

            // Act
            await detailsRepository.DeleteAsync(1);

            // Assert
            detailsSetMock.Verify(set => set.Remove(detail), Times.Once);
            dbMock.Verify(db => db.SaveChangesAsync(), Times.Once);
        }
    }
}