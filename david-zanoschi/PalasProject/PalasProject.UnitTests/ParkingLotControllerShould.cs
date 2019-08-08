using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Models.Models.Implementation;
using Moq;
using NUnit.Framework;
using PalasProject.Controllers;
using PalasProject.Repositories.Interfaces;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PalasProject.UnitTests
{
    [TestFixture]
    public class ParkingLotControllerShould
    {
        private static Mock<IParkingRepo<ParkingLot>> _mock;

        [OneTimeSetUp]
        private static void SetUp()
        {
            _mock = new Mock<IParkingRepo<ParkingLot>>();
        } 

        [Test]
        public async Task ReturnParkingLot_When_GetIsCalledWithId()
        {
            // Arrange
            var parkingLot = new ParkingLot
            {
                ParkingLotId = 2
            };
            _mock.Setup(r => r.GetByIdAsync(parkingLot.ParkingLotId)).Returns(Task.FromResult(parkingLot));
            var controller = new ParkingLotController(_mock.Object);

            // Act
            var actionResult  = await controller.Get(parkingLot.ParkingLotId);

            // Assert
            if (actionResult is OkObjectResult viewResult)
            {
                var actualParkingLot = viewResult.Value as ParkingLot;
                Assert.AreEqual(actualParkingLot, parkingLot);
            }
            else
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task ReturnAllParkingLots_When_GetIsCalled()
        {
            // Arrange
            var parkingLot = new ParkingLot();
            var parkingLots = new List<ParkingLot> {parkingLot};
            _mock.Setup(r => r.GetAllAsync()).Returns(Task.FromResult(parkingLots));
            var controller = new ParkingLotController(_mock.Object);

            // Act
            var actionResult = await controller.Get();

            // Assert
            if (actionResult is OkObjectResult viewResult)
            {
                var actualParkingLots = viewResult.Value as List<ParkingLot>;
                Assert.AreEqual(parkingLots, actualParkingLots);
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}
