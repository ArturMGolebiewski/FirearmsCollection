using FluentResults;
using MediatR;
using MyAPI.Domain.Manufacturer.Entities;
using MyAPI.Infrastructure.Manufacturers;

namespace MyAPI.Application.Queries.Handlers
{
    public sealed class FilterManufacturerQueryHandler : IRequestHandler<FilterManufacturersQuery, Result<List<Manufacturer>>>
    {
        private readonly IManufacturersReader _manufacturersReader;
        public FilterManufacturerQueryHandler(IManufacturersReader manufacturersReader)
        {
            _manufacturersReader = manufacturersReader;
        }
        public async Task<Result<List<Manufacturer>>> Handle(FilterManufacturersQuery request, CancellationToken cancellationToken)
        {
            return await _manufacturersReader.ReadAsync(request.PropertyValue, request.PropertyName, cancellationToken);
        }
    }
}
