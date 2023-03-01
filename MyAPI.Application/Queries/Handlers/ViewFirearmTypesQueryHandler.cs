using FluentResults;
using MediatR;
using MyAPI.Domain.FirearmType.Entities;
using MyAPI.Infrastructure.FirearmTypes;

namespace MyAPI.Application.Queries.Handlers
{
    public sealed class ViewFirearmTypesQueryHandler : IRequestHandler<ViewFirearmTypesQuery, Result<List<FirearmType>>>
    {
        private readonly IFirearmTypesReader _typesReader;

        public ViewFirearmTypesQueryHandler(IFirearmTypesReader typesReader)
        {
            _typesReader = typesReader;
        }

        public async Task<Result<List<FirearmType>>> Handle(ViewFirearmTypesQuery request, CancellationToken cancellationToken)
        {
            return await _typesReader.ReadFirearmTypesAsync(cancellationToken);
        }
    }
}
