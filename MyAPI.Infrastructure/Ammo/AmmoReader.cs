using AutoMapper;
using FluentResults;
using DomainAmmo = MyAPI.Domain.Ammunition.Entities.Ammunition;
using MyAPI.Infrastructure.Database;
using AutoMapper.Internal;
using System.Data.Common;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Infrastructure.Ammo
{
    public sealed class AmmoReader : IAmmoReader
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public AmmoReader(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> CheckIfAmmoNameUnique(Guid caliberId)
        {
            try
            {
                var nameExists = await _firearmContext.Ammunition.AnyAsync(x => x.CaliberId == caliberId);
                return nameExists
                    ? Result.Fail("This item already exists in the database.")
                    : Result.Ok();
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }

        public async Task<Result<List<DomainAmmo>>> ReadAsync(CancellationToken ct = default)
        {
            try
            {
                var ammoData = await _firearmContext.Ammunition
                    .ProjectTo<DomainAmmo>(_mapper.ConfigurationProvider.Internal())
                    .ToListAsync(ct);
                return Result.Ok(ammoData);
            }
            catch (DbException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }
    }
}
