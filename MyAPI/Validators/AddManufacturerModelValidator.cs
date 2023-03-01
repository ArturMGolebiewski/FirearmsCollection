using FluentValidation;
using MyAPI.Models;

namespace MyAPI.Validators
{
    public class AddManufacturerModelValidator : AbstractValidator<AddManufacturerModel>
    {
        private const short BerettaYearOfFounding = 1526;

        public AddManufacturerModelValidator()
        {
            RuleFor(x => x.ManufacturerName).NotEmpty().WithMessage("Please enter manufacturer.");
            RuleFor(x => x.CountryOfOrigin).NotEmpty().WithMessage("Please enter country name.");
            RuleFor(x => x.YearOfFounding).GreaterThan(BerettaYearOfFounding)
                .WithMessage($"Wrong value. Year must be greater than {BerettaYearOfFounding}.");
        }
    }
}
