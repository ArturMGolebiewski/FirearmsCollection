using AutoMapper;
using AutoMapper.Internal;
using AutoMapper.QueryableExtensions;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Firearm.Entities;
using MyAPI.Infrastructure.Database;
using System.Data.Common;

namespace MyAPI.Infrastructure.Firearms
{
    public sealed class FirearmsReader : IFirearmsReader
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public FirearmsReader(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> CheckIfFirearmNameUnique(string firearmName)
        {
            try
            {
                var nameExists = await _firearmContext.Firearms
                    .AnyAsync(x => x.FirearmModelName == firearmName);
                return nameExists 
                    ? Result.Fail("This model already exists in the database.") 
                    : Result.Ok();
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }

        public async Task<Result<List<Firearm>>> ReadFirearmsAsync(CancellationToken ct = default)
        {
            try
            {
                var firearmsData = await _firearmContext.Firearms
                    .ProjectTo<Firearm>(_mapper.ConfigurationProvider.Internal())
                    .ToListAsync(ct);
                return Result.Ok(firearmsData);
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }
    }
}
