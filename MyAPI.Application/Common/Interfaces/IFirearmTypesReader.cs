using FluentResults;
using MyAPI.Domain.FirearmType.Entities;

namespace MyAPI.Infrastructure.FirearmTypes
{
    public interface IFirearmTypesReader
    {
        Task<Result> CheckIfFirearmTypeUnique(string firearmType);
        Task<Result<List<FirearmType>>> ReadFirearmTypesAsync(CancellationToken ct = default);
    }
}