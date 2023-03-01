using FluentResults;
using MyAPI.Domain.Firearm.Entities;

namespace MyAPI.Infrastructure.Firearms
{
    public interface INewFirearmWriter
    {
        Task<Result> WriteFirearmAsync(Firearm firearm, CancellationToken ct = default);
    }
}