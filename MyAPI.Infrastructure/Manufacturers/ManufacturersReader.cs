using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Manufacturer.Entities;
using MyAPI.Infrastructure.Database;
using System.Data.Common;

namespace MyAPI.Infrastructure.Manufacturers;

public sealed class ManufacturersReader : IManufacturersReader
{
    private readonly FirearmContext _firearmContext;
    private readonly IMapper _mapper;

    public ManufacturersReader(FirearmContext firearmContext, IMapper mapper)
    {
        _firearmContext = firearmContext;
        _mapper = mapper;
    }

    public async Task<Result<List<Manufacturer>>> ReadAsync(CancellationToken ct = default)
    {
        try
        {
            var manufacturersData = await _firearmContext.Manufacturer
                .ProjectTo<Manufacturer>(_mapper.ConfigurationProvider.Internal())
                .ToListAsync(ct);
            return Result.Ok(manufacturersData);
        }
        catch (DbException ex)
        {
            return Result.Fail(new ExceptionalError(ex));
        }
    }

    public async Task<Result<List<Manufacturer>>> ReadAsync<TColumnType>(TColumnType value, 
        string columnName, CancellationToken ct = default) where TColumnType : notnull
    {
        try
        {
            var manufacturersData = await _firearmContext.Manufacturer
                .Where(x => EF.Property<TColumnType>(x, columnName).Equals(value))
                .ProjectTo<Manufacturer>(_mapper.ConfigurationProvider.Internal())
                .ToListAsync(ct);
            return Result.Ok(manufacturersData);
        }
        catch (DbException ex)
        {
            return Result.Fail(new ExceptionalError(ex));
        }
    }
}
