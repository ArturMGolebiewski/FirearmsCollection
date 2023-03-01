using FluentValidation;
using MyAPI.Models;

namespace MyAPI.Validators
{
    public sealed class AddCaliberModelValidator : AbstractValidator<AddCaliberModel>
    {
        public AddCaliberModelValidator()
        {
            RuleFor(x => x.CaliberName).NotEmpty().WithMessage("Please enter caliber.");
        }
    }
}
