using FluentResults;
using MediatR;

namespace MyAPI.Application.Commands
{
    public sealed class AddFirearmTypeCommand : IRequest<Result>
    {
        public string Type { get; }
        public AddFirearmTypeCommand(string firearmType)
        {
            Type = firearmType;
        }
    }
}
