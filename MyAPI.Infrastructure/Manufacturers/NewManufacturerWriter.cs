using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Application.Common.Interfaces;
using MyAPI.Domain.Manufacturer.Entities;
using MyAPI.Infrastructure.Database;
using DatabaseManufacturer = MyAPI.Infrastructure.Database.Entities.Manufacturer;

namespace MyAPI.Infrastructure.Manufacturers
{
    public sealed class NewManufacturerWriter : INewManufacturerWriter
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public NewManufacturerWriter(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> WriteAsync(Manufacturer manufacturer, CancellationToken ct = default)
        {
            try
            {
                var newManufacturer = _mapper.Map<DatabaseManufacturer>(manufacturer);
                newManufacturer.CreatedAt = DateTime.UtcNow;
                _firearmContext.Manufacturer.Add(newManufacturer);
                await _firearmContext.SaveChangesAsync(ct);
                return Result.Ok();
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }
    }
}
