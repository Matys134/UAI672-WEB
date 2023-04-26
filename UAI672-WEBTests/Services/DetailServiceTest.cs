using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAI672_WEB.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAI672_WEB.Models;
using UAI672_WEB.Repositories;
using Moq;

namespace UAI672_WEB.Services.Tests
{
    [TestClass()]
    public class DetailServiceTests
    {
        [TestMethod()]
        public void DetailServiceTest()
        {
            // Arrange
            var detailsRepository = new Mock<IRepository<Details>>().Object;

            // Act
            var detailService = new DetailService(detailsRepository);

            // Assert
            Assert.AreEqual(detailsRepository, detailService.Get());
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            var detailsRepository = new Mock<IRepository<Details>>();
            var detailService = new DetailService(detailsRepository.Object);
            var expectedDetail = new Details { ID = 1, Name = "Detail1" };
            detailsRepository.Setup(r => r.GetById(1)).Returns(expectedDetail);

            // Act
            var actualDetail = detailService.GetById(1);

            // Assert
            Assert.AreEqual(expectedDetail, actualDetail);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var detailsRepository = new Mock<IRepository<Details>>();
            var detailService = new DetailService(detailsRepository.Object);
            var newDetail = new Details { ID = 4, Name = "Detail4" };

            // Act
            detailService.Add(newDetail);

            // Assert
            detailsRepository.Verify(r => r.Add(It.IsAny<Details>()), Times.Once);
            detailsRepository.Verify(r => r.Add(newDetail), Times.Once);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            var detailsRepository = new Mock<IRepository<Details>>();
            var detailService = new DetailService(detailsRepository.Object);
            var existingDetail = new Details { Id = 1, Name = "Detail1" };

            // Act
            detailService.Update(existingDetail);

            // Assert
            detailsRepository.Verify(r => r.Update(It.IsAny<Details>()), Times.Once);
            detailsRepository.Verify(r => r.Update(existingDetail), Times.Once);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var detailsRepository = new Mock<IRepository<Details>>();
            var detailService = new DetailService(detailsRepository.Object);
            var idToDelete = 1;

            // Act
            detailService.Delete(idToDelete);

            // Assert
            detailsRepository.Verify(r => r.Delete(It.IsAny<int>()), Times.Once);
            detailsRepository.Verify(r => r.Delete(idToDelete), Times.Once);
        }
    }
}

