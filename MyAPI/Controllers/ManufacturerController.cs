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
    public class ManufacturerController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IValidator<AddManufacturerModel> _manufacturerModelValidator;
        private readonly FirearmContext _firearmContext;

        public ManufacturerController(IMediator mediator, IValidator<AddManufacturerModel> manufacturerModelValidator, FirearmContext firearmContext)
        {
            _mediator = mediator;
            _manufacturerModelValidator = manufacturerModelValidator;
            _firearmContext = firearmContext;
        }

        [HttpPost("add-manufacturer")]
        public async Task<IActionResult> AddManufacturer(AddManufacturerModel model, CancellationToken ct = default)
        {
            var validationResult = await _manufacturerModelValidator.ValidateAsync(model);
            if (!validationResult.IsValid)
            {
                validationResult.AddToModelState(ModelState);
                return BadRequest(ModelState);
            }

            if (_firearmContext.Manufacturer.Any(x => x.ManufacturerName == model.ManufacturerName))
            {
                return Problem("This manufacturer already exists in the database");
            }
            var result = await _mediator.Send
                (new AddManufacturerCommand(model.ManufacturerName, model.CountryOfOrigin, model.YearOfFounding), ct);
            return result.IsSuccess ? Ok($"Successfully added {model.ManufacturerName} to the database.") 
                : Problem("Firepaws Collection encountered an error while adding manufacturer to the database");
        }

        [HttpGet("view-manufacturers")]
        public async Task<IActionResult> ViewManufacturers(CancellationToken ct = default)
        {
            var result = await _mediator.Send(new ViewManufacturersQuery(), ct);
            return result.IsSuccess ? Ok(result.Value) : Problem();
        }

        [HttpPost("filter-manufacturers")]
        public async Task<IActionResult> FilterManufacturers(ManufacturerFilterModel model, CancellationToken ct = default)
        {
            var filterData = await _mediator.Send(model.ToQuery(), ct);
            return Ok(filterData);
        }
    }
}