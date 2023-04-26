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
            // Inicializace mocku pro Model1
            dbMock = new Mock<Model1>();

            // Vytvoření instance DetailsRepository s použitím mocku pro Model1
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
        public void GetAllTest()
        {
            // Arrange
            var details = new List<Details>
            {
                new Details { ID = 1, Name = "Detail1", Surname = "Surname1" },
                new Details { ID = 2, Name = "Detail2", Surname = "Surname2" },
                new Details { ID = 3, Name = "Detail3", Surname = "Surname3" }
            };
            dbMock.Setup(db => db.Details.ToList()).Returns(details);

            // Act
            var result = detailsRepository.GetAll();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(details.Count, result.Count());
            CollectionAssert.AreEqual(details, result.ToList());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            dbMock.Setup(db => db.Details.Find(1)).Returns(detail);

            // Act
            var result = detailsRepository.GetById(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(detail, result);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            var detailsSetMock = new Mock<DbSet<Details>>();
            dbMock.Setup(db => db.Details).Returns(detailsSetMock.Object);

            // Act
            detailsRepository.Add(detail);

            // Assert
            detailsSetMock.Verify(set => set.Add(detail), Times.Once);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            var detailsSetMock = new Mock<DbSet<Details>>();
            dbMock.Setup(db => db.Details).Returns(detailsSetMock.Object);

            // Act
            detailsRepository.Update(detail);

            // Assert
            detailsSetMock.Verify(set => set.Attach(detail), Times.Once);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var detail = new Details { ID = 1, Name = "Detail1", Surname = "Surname1" };
            var detailsSetMock = new Mock<DbSet<Details>>();
            detailsSetMock.Setup(set => set.Remove(detail));
            dbMock.Setup(db => db.Details).Returns(detailsSetMock.Object);

            // Act
            detailsRepository.Delete(1);

            // Assert
            detailsSetMock.Verify(set => set.Remove(detail), Times.Once);
            dbMock.Verify(db => db.SaveChanges(), Times.Once);
        }
    }
}