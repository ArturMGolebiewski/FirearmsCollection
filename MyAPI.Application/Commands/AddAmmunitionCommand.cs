using FluentResults;
using MediatR;

namespace MyAPI.Application.Commands
{
    public sealed class AddAmmunitionCommand : IRequest<Result>
    {
        public Guid CaliberId { get; }
        public Guid FirearmTypeId { get; }
        public int Count { get; }

        public AddAmmunitionCommand(Guid caliberId, Guid firearmTypeId, int count)
        {
            CaliberId = caliberId;
            FirearmTypeId = firearmTypeId;
            Count = count;
        }
    }
}
