using FluentResults;
using MyAPI.Domain.Caliber.Entities;

namespace MyAPI.Infrastructure.Calibers
{
    public interface ICaliberReader
    {
        Task<Result> CheckIfCaliberNameUnique(string caliberName);
        Task<Result<List<Caliber>>> ReadCalibersAsync(CancellationToken ct = default);
    }
}