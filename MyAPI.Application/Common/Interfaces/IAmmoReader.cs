using FluentResults;
using MyAPI.Domain.Ammunition.Entities;

namespace MyAPI.Infrastructure.Ammo
{
    public interface IAmmoReader
    {
        Task<Result> CheckIfAmmoNameUnique(Guid caliberId);
        Task<Result<List<Ammunition>>> ReadAsync(CancellationToken ct = default);
    }
}