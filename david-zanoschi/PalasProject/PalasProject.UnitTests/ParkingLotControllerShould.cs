using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PalasProject.Controllers;
using PalasProject.Models.Impl;
using PalasProject.Repositories;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PalasProject.UnitTests
{
    [TestFixture]
    public class ParkingLotControllerShould
    {
        [Test]
        public async Task ReturnParkingLot_When_GetIsCalledWithId()
        {
            // Arrange
            var mock = new Mock<IParkingRepo<ParkingLot>>();
            var parkingLot = new ParkingLot
            {
                ParkingLotId = 2
            };
            mock.Setup(r => r.GetById(parkingLot.ParkingLotId)).Returns(Task.FromResult(parkingLot));
            var controller = new ParkingLotController(mock.Object);

            // Act
            var actualParkingLotActionResult  = await controller.Get(parkingLot.ParkingLotId);
            Assert.IsNotNull(actualParkingLotActionResult);
            var actualParkingLotViewResult = actualParkingLotActionResult as OkObjectResult;
            Assert.IsNotNull(actualParkingLotViewResult);
            var actualParkingLot = actualParkingLotViewResult.Value as ParkingLot;

            // Assert
            Assert.AreEqual(actualParkingLot, parkingLot);
        }

        [Test]
        public async Task ReturnAllParkingLots_When_GetIsCalled()
        {
            // Arrange
            var mock = new Mock<IParkingRepo<ParkingLot>>();
            var parkingLot = new ParkingLot();
            var parkingLots = new List<ParkingLot> {parkingLot};
            mock.Setup(r => r.GetAll()).Returns(Task.FromResult(parkingLots));
            var controller = new ParkingLotController(mock.Object);

            // Act
            var actualParkingLotsActionResult = await controller.Get();
            Assert.IsNotNull(actualParkingLotsActionResult);
            var actualParkingLotsViewResult = actualParkingLotsActionResult as OkObjectResult;
            Assert.IsNotNull(actualParkingLotsViewResult);
            var actualParkingLots = actualParkingLotsViewResult.Value as List<ParkingLot>;

            // Assert
            Assert.AreEqual(parkingLots, actualParkingLots);
        }
    }
}
