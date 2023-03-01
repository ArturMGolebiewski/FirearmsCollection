using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Application.Commands;
using MyAPI.Extensions;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AmmunitionController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddAmmunitionModel> _ammunitionModelValidator;

        public AmmunitionController(IMediator mediator, IValidator<AddAmmunitionModel> ammunitionModelValidator)
        {
            _mediator = mediator;
            _ammunitionModelValidator = ammunitionModelValidator;
        }

        [HttpPost("add-ammunition")]
        public async Task<IActionResult> AddAmmunition(AddAmmunitionModel model, CancellationToken ct = default)
        {
            var validationResult = await _ammunitionModelValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(new AddAmmunitionCommand(model.CaliberId, model.TypeId, model.Count), ct);
            return result.IsSuccess
                ? Ok("Successfully added ammunition.")
                : Problem("Firepaws Collection encountered an error while adding ammunition to the database.");
        }
    }
}
