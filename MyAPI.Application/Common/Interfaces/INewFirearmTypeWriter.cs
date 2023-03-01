using FluentResults;
using MyAPI.Domain.FirearmType.Entities;

namespace MyAPI.Infrastructure.FirearmTypes
{
    public interface INewFirearmTypeWriter
    {
        Task<Result> WriteFirearmTypeAsync(FirearmType firearmType, CancellationToken ct = default);
    }
}