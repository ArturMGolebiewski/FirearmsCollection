using FluentResults;
using MyAPI.Domain.Firearm.Entities;

namespace MyAPI.Infrastructure.Firearms
{
    public interface IFirearmsReader
    {
        Task<Result> CheckIfFirearmNameUnique(string firearmName);
        Task<Result<List<Firearm>>> ReadFirearmsAsync(CancellationToken ct = default);
    }
}