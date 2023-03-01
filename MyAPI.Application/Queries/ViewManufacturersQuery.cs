using FluentResults;
using MediatR;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Application.Queries
{
    public sealed class ViewManufacturersQuery : IRequest<Result<List<Manufacturer>>>
    {

    }
}
