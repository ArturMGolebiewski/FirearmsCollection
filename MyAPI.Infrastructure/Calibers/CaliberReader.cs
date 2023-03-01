using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Caliber.Entities;
using MyAPI.Infrastructure.Database;
using System.Data.Common;

namespace MyAPI.Infrastructure.Calibers
{
    public sealed class CaliberReader : ICaliberReader
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public CaliberReader(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> CheckIfCaliberNameUnique(string caliberName)
        {
            try
            {
                var nameExists = await _firearmContext.Calibers.AnyAsync(x => x.CaliberName == caliberName);
                return nameExists
                    ? Result.Fail("This caliber already exists in the database.")
                    : Result.Ok();
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }

        public async Task<Result<List<Caliber>>> ReadCalibersAsync(CancellationToken ct = default)
        {
            try
            {
                var calibersData = await _firearmContext.Calibers
                    .ProjectTo<Caliber>(_mapper.ConfigurationProvider.Internal())
                    .ToListAsync(ct);
                return Result.Ok(calibersData);
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }
    }
}
