using FluentResults;
using MediatR;
using MyAPI.Domain.FirearmType.Entities;

namespace MyAPI.Application.Queries
{
    public sealed class ViewFirearmTypesQuery : IRequest<Result<List<FirearmType>>>
    {
    }
}
