using FluentResults;
using MyAPI.Domain.Ammunition.Entities;

namespace MyAPI.Infrastructure.Ammo
{
    public interface INewAmmoWriter
    {
        Task<Result> WriteAsync(Ammunition ammo, CancellationToken ct = default);
    }
}