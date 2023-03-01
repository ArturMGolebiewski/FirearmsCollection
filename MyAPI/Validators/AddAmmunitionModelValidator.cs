using FluentValidation;
using MyAPI.Models;

namespace MyAPI.Validators
{
    public sealed class AddAmmunitionModelValidator : AbstractValidator<AddAmmunitionModel>
    {
        public AddAmmunitionModelValidator()
        {
            RuleFor(x => x.CaliberId).NotEmpty().WithMessage("Please choose caliber of specified ammunition.");
            RuleFor(x => x.TypeId).NotEmpty().WithMessage("Please enter ammunition type(pistol/rifle/shotgun).");
        }
    }
}
