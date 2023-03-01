using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Ammunition.Entities;
using MyAPI.Infrastructure.Database;
using DatabaseAmmo = MyAPI.Infrastructure.Database.Entities.Ammunition;

namespace MyAPI.Infrastructure.Ammo
{
    public sealed class NewAmmoWriter : INewAmmoWriter
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;
        public NewAmmoWriter(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> WriteAsync(Ammunition ammo, CancellationToken ct = default)
        {
            try
            {
                var newAmmo = _mapper.Map<DatabaseAmmo>(ammo);
                newAmmo.CreatedAt = DateTime.UtcNow;
                _firearmContext.Ammunition.Add(newAmmo);
                await _firearmContext.SaveChangesAsync(ct);
                return Result.Ok();
            }
            catch (DbUpdateException ex)
            {
                return Result.Fail(new ExceptionalError(ex));
            }
        }
    }
}
