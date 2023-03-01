using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Application.Commands;
using MyAPI.Application.Queries;
using MyAPI.Extensions;
using MyAPI.Infrastructure.Database;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class FirearmController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddFirearmModel> _firearmModelValidator;

        public FirearmController(IMediator mediator, IValidator<AddFirearmModel> firearmModelValidator)
        {
            _mediator = mediator;
            _firearmModelValidator = firearmModelValidator;
        }

        [HttpPost("add-firearm")]
        public async Task<IActionResult> AddFirearm(AddFirearmModel model, CancellationToken ct = default)
        {
            var validationResult = await _firearmModelValidator.ValidateAsync(model);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            var result = await _mediator.Send(
                new AddFirearmCommand(model.ManufacturerId, model.FirearmModelName, model.FirearmTypeId, model.CaliberId), ct);
            return result.IsSuccess 
                ? Ok($"Successfully added {model.FirearmModelName} to the database.") 
                : Problem("Firepaws Collection encountered an error while adding firearm to the database");
        }

        [HttpGet("view-firearms")]
        public async Task<IActionResult> ViewFirearms(CancellationToken ct = default)
        {
            var firearmData = await _mediator.Send(new ViewFirearmsQuery(), ct);
            return Ok(firearmData);
        }
    }
}
