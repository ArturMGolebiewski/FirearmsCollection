using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAPI.Application.Commands;
using MyAPI.Application.Queries;
using MyAPI.Extensions;
using MyAPI.Models;

namespace MyAPI.Controllers
{
    [ApiController]
    [Route("/api/v1/[controller]")]
    public class FirearmTypeController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddFirearmTypeModel> _firearmTypeModelValidator;

        public FirearmTypeController(IMediator mediator, IValidator<AddFirearmTypeModel> firearmTypeModelValidator)
        {
            _mediator = mediator;
            _firearmTypeModelValidator = firearmTypeModelValidator;
        }

        [HttpPost("add-type")]
        public async Task<IActionResult> AddFirearmType(AddFirearmTypeModel model, CancellationToken ct = default)
        {
            var validationResult = await _firearmTypeModelValidator.ValidateAsync(model);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(validationResult);
            }
            var result = await _mediator.Send(
                new AddFirearmTypeCommand(model.FirearmType), ct);
            return result.IsSuccess
                ? Ok("Successfully added firearm type to the database.")
                : Problem("Firepaws Collection encountered an error while adding firearm type to the database");
        }

        [HttpGet("view-types")]
        public async Task<IActionResult> ViewFirearmTypes(CancellationToken ct = default)
        {
            var firearmTypesData = await _mediator.Send(new ViewFirearmTypesQuery(), ct);
            return Ok(firearmTypesData);
        }
    }
}
