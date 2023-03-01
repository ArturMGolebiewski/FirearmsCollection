using FluentResults;
using MyAPI.Domain.Caliber.Entities;

namespace MyAPI.Infrastructure.Calibers
{
    public interface INewCaliberWriter
    {
        Task<Result> WriteCaliberAsync(Caliber caliber, CancellationToken ct = default);
    }
}