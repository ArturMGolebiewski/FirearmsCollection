using FluentResults;
using MediatR;
using MyAPI.Domain.Firearm.Entities;
using MyAPI.Infrastructure.Firearms;

namespace MyAPI.Application.Queries.Handlers
{
    public sealed class ViewFirearmsQueryHandler : IRequestHandler<ViewFirearmsQuery, Result<List<Firearm>>>
    {
        private readonly IFirearmsReader _firearmsReader;

        public ViewFirearmsQueryHandler(IFirearmsReader firearmsReader)
        {
            _firearmsReader = firearmsReader;
        }

        public async Task<Result<List<Firearm>>> Handle(ViewFirearmsQuery request, CancellationToken cancellationToken)
        {
            return await _firearmsReader.ReadFirearmsAsync(cancellationToken);
        }
    }
}
