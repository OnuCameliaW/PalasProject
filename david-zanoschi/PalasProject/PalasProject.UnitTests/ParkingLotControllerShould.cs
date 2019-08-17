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
        public static void SetUp()
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
            var actionResult = await controller.Get(parkingLot.ParkingLotId);

            if (actionResult is OkObjectResult viewResult)
            {
                var actualParkingLot = viewResult.Value as ParkingLot;

                // Assert
                Assert.AreEqual(actualParkingLot, parkingLot);
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

            if (actionResult is OkObjectResult viewResult)
            {
                var actualParkingLots = viewResult.Value as ParkingLot;

                // Assert
                Assert.AreEqual(parkingLots, actualParkingLots);
            }
        }
    }
}
