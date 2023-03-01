using FluentResults;
using MediatR;

namespace MyAPI.Application.Commands
{
    public sealed class AddFirearmCommand : IRequest<Result>
    {
        public Guid ManufacturerId { get; }
        public Guid FirearmTypeId { get; }
        public Guid CaliberId { get; }
        public string FirearmModelName { get; }
        public AddFirearmCommand(Guid manufacturerId, string firearmModelName, Guid firearmTypeId, Guid caliberId)
        {
            ManufacturerId = manufacturerId;
            FirearmModelName = firearmModelName;
            FirearmTypeId = firearmTypeId;
            CaliberId = caliberId;
        }
    }
}
