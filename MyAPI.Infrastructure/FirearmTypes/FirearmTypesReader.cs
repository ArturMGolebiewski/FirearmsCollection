using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.FirearmType.Entities;
using MyAPI.Infrastructure.Database;
using System.Data.Common;

namespace MyAPI.Infrastructure.FirearmTypes
{
    public sealed class FirearmTypesReader : IFirearmTypesReader
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public FirearmTypesReader(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> CheckIfFirearmTypeUnique(string firearmType)
        {
            try
            {
                var typeExists = await _firearmContext.FirearmType
                    .AnyAsync(x => x.Type == firearmType);
                return typeExists
                    ? Result.Fail("This firearm type already exists in the database.")
                    : Result.Ok();
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }

        public async Task<Result<List<FirearmType>>> ReadFirearmTypesAsync(CancellationToken ct = default)
        {
            try
            {
                var firearmTypesData = await _firearmContext.FirearmType
                    .ProjectTo<FirearmType>(_mapper.ConfigurationProvider.Internal())
                    .ToListAsync();
                return Result.Ok(firearmTypesData);
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }
    }
}
