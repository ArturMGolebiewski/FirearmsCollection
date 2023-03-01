using FluentResults;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Application.Common.Interfaces
{
    public interface INewManufacturerWriter
    {
        Task<Result> WriteAsync(Manufacturer manufacturer, CancellationToken ct = default);
    }
}