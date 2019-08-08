using System.Text.RegularExpressions;
using FluentValidation;
using Models.Models.Implementation;

namespace Models.Validators
{
    public class ParkingLotValidator : AbstractValidator<ParkingLot>
    {
        public ParkingLotValidator()
        {
            RuleFor(pl => pl.NumberOfParkingSpots)
                .NotEmpty()
                .WithMessage("Number of parking spots is required.")
                .DependentRules(() =>
                    RuleFor(pl => pl.NumberOfParkingSpots)
                        .Must(BeAPositiveNumber)
                        .WithMessage("Number of parking spots must be positive."));
            RuleFor(pl => pl.Floor)
                .Matches(new Regex(@"^[A-Z]\-\d$"))
                .WithMessage(@"Floor must match [A-Z]\-[0-9]");
            RuleFor(pl => pl.Description)
                .MaximumLength(50)
                .WithMessage("Description must have maximum 50 characters");
        }

        private static bool BeAPositiveNumber(string value)
        {
            var isNumber = int.TryParse(value, out var parsedValue);
            var result = isNumber && parsedValue > 0;

            return result;
        }
    }
}
