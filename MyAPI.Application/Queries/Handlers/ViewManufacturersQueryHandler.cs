using FluentResults;
using MediatR;
using MyAPI.Domain.Manufacturer.Entities;
using MyAPI.Infrastructure.Manufacturers;

namespace MyAPI.Application.Queries.Handlers
{
    public sealed class ViewManufacturersQueryHandler : 
        IRequestHandler<ViewManufacturersQuery, Result<List<Manufacturer>>>
    {
        private readonly IManufacturersReader _manufacturerReader;

        public ViewManufacturersQueryHandler(IManufacturersReader manufacturerReader)
        {
            _manufacturerReader = manufacturerReader;
        }

        public async Task<Result<List<Manufacturer>>> Handle(
            ViewManufacturersQuery request, CancellationToken cancellationToken)
        {
            return await _manufacturerReader.ReadAsync(cancellationToken);
        }
    }
}
