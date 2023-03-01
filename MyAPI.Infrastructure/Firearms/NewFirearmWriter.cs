using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Firearm.Entities;
using MyAPI.Infrastructure.Database;
using DatabaseFirearm = MyAPI.Infrastructure.Database.Entities.Firearm;

namespace MyAPI.Infrastructure.Firearms
{
    public sealed class NewFirearmWriter : INewFirearmWriter
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public NewFirearmWriter(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> WriteFirearmAsync(Firearm firearm, CancellationToken ct = default)
        {
            try
            {
                var newFirearm = _mapper.Map<DatabaseFirearm>(firearm);
                newFirearm.CreatedAt = DateTime.UtcNow;
                _firearmContext.Firearms.Add(newFirearm);
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
