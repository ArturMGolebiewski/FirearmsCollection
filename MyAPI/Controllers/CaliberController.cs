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
    public class CaliberController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddCaliberModel> _caliberValidator;

        public CaliberController(IMediator mediator, IValidator<AddCaliberModel> caliberValidator)
        {
            _mediator = mediator;
            _caliberValidator = caliberValidator;
        }

        [HttpPost("add-caliber")]
        public async Task<IActionResult> AddCaliber(AddCaliberModel model, CancellationToken ct = default)
        {
            var validationResult = await _caliberValidator.ValidateAsync(model);
            if(!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }
            var result = await _mediator.Send(new AddCaliberCommand(model.CaliberName), ct);
            return result.IsSuccess
                ? Ok($"Successfully added {model.CaliberName} to the database.")
                : Problem("Firepaws Collection encountered an error while adding firearm to the database");
        }
    }
}
