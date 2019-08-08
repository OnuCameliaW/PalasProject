using System;
using System.Threading.Tasks;
using Castle.Core.Internal;
using FluentValidation.TestHelper;
using NUnit;
using Moq;
using FluentValidation.Validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Models.Validators;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using PalasProject.Controllers;
using PalasProject.Models.Impl;
using PalasProject.Repositories;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PalasProject.UnitTests
{
    [TestFixture()]
    public class ParkingLotValidatorShould
    {
        private ParkingLotValidator parkingLotValidator;
        private ParkingLot parkingLot;

        [SetUp]
        public void SetUp()
        {
            parkingLotValidator = new ParkingLotValidator();
            parkingLot = ParkingLot.CreateValidParkingLot();
        }

        [TestCase("NumberOfParkingSpots", "16", "")]
        [TestCase("NumberOfParkingSpots", "", "Number of parking spots is required.")]
        [TestCase("NumberOfParkingSpots", @"-3", "Number of parking spots must be positive.")]
        [TestCase("Floor", "C-3", "")]
        [TestCase("Floor", "AB-65", @"Floor must match [A-Z]\-[0-9]")]
        [TestCase("Description", "That is some basic parking lot", "")]
        [TestCase("Description", "*********************************************************", "Description must have maximum 50 characters")]
        public void ParkingLotValidatorTest(string property, string value, string errorMessage)
        {
            parkingLot.GetType().GetProperty(property)?.SetValue(parkingLot, value);

            var result = parkingLotValidator.Validate(parkingLot);

            if (errorMessage == "")
            {
                parkingLotValidator.ShouldNotHaveValidationErrorFor(p => p.GetType().GetProperty(property), parkingLot);
            }
            else
            {
                Assert.AreEqual(errorMessage, result.Errors[0].ErrorMessage);
            }
        }
    }
}
