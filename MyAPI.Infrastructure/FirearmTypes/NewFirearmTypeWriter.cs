using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.FirearmType.Entities;
using MyAPI.Infrastructure.Database;
using DatabaseFirearmType = MyAPI.Infrastructure.Database.Entities.FirearmType;

namespace MyAPI.Infrastructure.FirearmTypes
{
    public sealed class NewFirearmTypeWriter : INewFirearmTypeWriter
    {
        private readonly FirearmContext _firearmContext;
        private readonly IMapper _mapper;

        public NewFirearmTypeWriter(FirearmContext firearmContext, IMapper mapper)
        {
            _firearmContext = firearmContext;
            _mapper = mapper;
        }

        public async Task<Result> WriteFirearmTypeAsync(FirearmType firearmType, CancellationToken ct = default)
        {
            try
            {
                var newFirearmType = _mapper.Map<DatabaseFirearmType>(firearmType);
                newFirearmType.CreatedAt = DateTime.UtcNow;
                _firearmContext.FirearmType.Add(newFirearmType);
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
