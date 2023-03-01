using FluentValidation;
using MyAPI.Models;

namespace MyAPI.Validators
{
    public class AddFirearmModelValidator : AbstractValidator<AddFirearmModel>
    {
        public AddFirearmModelValidator()
        {
            RuleFor(x => x.ManufacturerId).NotEmpty().WithMessage("Please enter manufacturer.");
            RuleFor(x => x.FirearmModelName).NotEmpty().WithMessage("Please enter firearm model.");
            RuleFor(x => x.FirearmTypeId).NotEmpty().WithMessage("Please enter firearm type.");
            RuleFor(x => x.CaliberId).NotEmpty().WithMessage("Please enter caliber.");
        }
    }
}
