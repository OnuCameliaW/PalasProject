using FluentValidation.TestHelper;
using Models.Models.Implementation;
using Models.Validators;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PalasProject.UnitTests
{
    [TestFixture()]
    public class ParkingLotValidatorShould
    {
        private ParkingLotValidator _parkingLotValidator;
        private ParkingLot _parkingLot;

        [SetUp]
        public void SetUp()
        {
            _parkingLotValidator = new ParkingLotValidator();
            _parkingLot = new ParkingLot("15", true, "A-5", "Basic parking lot");
        }

        [TestCase("NumberOfParkingSpots", "16")]
        [TestCase("Floor", "C-3")]
        [TestCase("Description", "That is some basic parking lot")]
        public void ParkingLotValidatorTestForValidParkingLot(string property, string value)
        {
            // Arrange
            _parkingLot.GetType().GetProperty(property)?.SetValue(_parkingLot, value);

            // Act
            _parkingLotValidator.Validate(_parkingLot);

            // Assert
            _parkingLotValidator.ShouldNotHaveValidationErrorFor(p => p.GetType().GetProperty(property), _parkingLot);
        }


        [TestCase("NumberOfParkingSpots", "", "Number of parking spots is required.")]
        [TestCase("NumberOfParkingSpots", @"-3", "Number of parking spots must be positive.")]
        [TestCase("Floor", "AB-65", @"Floor must match [A-Z]\-[0-9]")]
        [TestCase("Description", "*********************************************************", "Description must have maximum 50 characters")]
        public void ParkingLotValidatorTest(string property, string value, string errorMessage)
        {
            // Arrange
            _parkingLot.GetType().GetProperty(property)?.SetValue(_parkingLot, value);

            // Act
            var result = _parkingLotValidator.Validate(_parkingLot);

            // Assert
            Assert.AreEqual(errorMessage, result.Errors[0].ErrorMessage);
        }
    }
}
