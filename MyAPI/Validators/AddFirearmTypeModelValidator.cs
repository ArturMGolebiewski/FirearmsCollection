using FluentValidation;
using MyAPI.Models;

namespace MyAPI.Validators
{
    public class AddFirearmTypeModelValidator : AbstractValidator<AddFirearmTypeModel>
    {
        public AddFirearmTypeModelValidator()
        {
            RuleFor(x => x.FirearmType).NotEmpty().WithMessage("Please enter firearm type.");
        }
    }
}
