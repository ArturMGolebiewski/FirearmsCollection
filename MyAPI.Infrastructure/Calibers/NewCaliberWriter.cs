using AutoMapper;
using FluentResults;
using Microsoft.EntityFrameworkCore;
using MyAPI.Domain.Caliber.Entities;
using MyAPI.Infrastructure.Database;
using DatabaseCaliber = MyAPI.Infrastructure.Database.Entities.Caliber;

namespace MyAPI.Infrastructure.Calibers;

public sealed class NewCaliberWriter : INewCaliberWriter
{
    private readonly FirearmContext _firearmContext;
    private readonly IMapper _mapper;

    public NewCaliberWriter(FirearmContext firearmContext, IMapper mapper)
    {
        _firearmContext = firearmContext;
        _mapper = mapper;
    }

    public async Task<Result> WriteCaliberAsync(Caliber caliber, CancellationToken ct = default)
    {
        try
        {
            var newCaliber = _mapper.Map<DatabaseCaliber>(caliber);
            newCaliber.CreatedAt = DateTime.UtcNow;
            _firearmContext.Calibers.Add(newCaliber);
            await _firearmContext.SaveChangesAsync(ct);
            return Result.Ok();
        }
        catch (DbUpdateException ex)
        {
            return Result.Fail(new ExceptionalError(ex));
        }
    }
}
