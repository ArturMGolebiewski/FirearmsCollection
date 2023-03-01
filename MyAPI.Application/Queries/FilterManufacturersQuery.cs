using FluentResults;
using MediatR;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Application.Queries
{
    public sealed class FilterManufacturersQuery : IRequest<Result<List<Manufacturer>>>
    {
        public string PropertyName { get; init; } = string.Empty;
        public string PropertyValue { get; init; } = string.Empty;


    }
}
