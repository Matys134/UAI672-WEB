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
        private Mock<IRepository<Details>> detailsRepository;
        private DetailService _detailService;

        [TestInitialize]
        public void Setup()
        {
            detailsRepository = new Mock<IRepository<Details>>();
            _detailService = new DetailService(detailsRepository.Object);
        }

        [TestMethod()]
        public void GetByIdTest()
        {
            // Arrange
            var expectedDetail = new Details { ID = 1, Name = "Detail1" };
            detailsRepository.Setup(r => r.GetByIdAsync(1)).Returns(expectedDetail);

            // Act
            var actualDetail = _detailService.GetById(1);

            // Assert
            Assert.AreEqual(expectedDetail, actualDetail);
        }

        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var newDetail = new Details { ID = 4, Name = "Detail4" };

            // Act
            _detailService.Add(newDetail);

            // Assert
            detailsRepository.Verify(r => r.AddAsync(It.IsAny<Details>()), Times.Once);
            detailsRepository.Verify(r => r.AddAsync(newDetail), Times.Once);
        }

        [TestMethod()]
        public void UpdateTest()
        {
            // Arrange
            var existingDetail = new Details { ID = 1, Name = "Detail1" };

            // Act
            _detailService.Update(existingDetail);

            // Assert
            detailsRepository.Verify(r => r.UpdateAsync(It.IsAny<Details>()), Times.Once);
            detailsRepository.Verify(r => r.UpdateAsync(existingDetail), Times.Once);
        }

        [TestMethod()]
        public void DeleteTest()
        {
            // Arrange
            var idToDelete = 1;

            // Act
            _detailService.Delete(idToDelete);

            // Assert
            detailsRepository.Verify(r => r.DeleteAsync(It.IsAny<int>()), Times.Once);
            detailsRepository.Verify(r => r.DeleteAsync(idToDelete), Times.Once);
        }
    }

}

