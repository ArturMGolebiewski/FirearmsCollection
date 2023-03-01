using FluentResults;
using MediatR;
using MyAPI.Domain.Firearm.Entities;

namespace MyAPI.Application.Queries
{
    public sealed class ViewFirearmsQuery : IRequest<Result<List<Firearm>>>
    {

    }
}
