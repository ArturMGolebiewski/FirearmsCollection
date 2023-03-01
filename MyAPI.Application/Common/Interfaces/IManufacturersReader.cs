using FluentResults;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Infrastructure.Manufacturers
{
    public interface IManufacturersReader
    {
        Task<Result<List<Manufacturer>>> ReadAsync(CancellationToken ct = default);
        Task<Result<List<Manufacturer>>> ReadAsync<TColumnType>(TColumnType value,
            string columnName, CancellationToken ct = default) where TColumnType : notnull;
    }
}