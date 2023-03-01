using FluentResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Commands
{
    public sealed class AddCaliberCommand : IRequest<Result>
    {
        public string CaliberName { get; }

        public AddCaliberCommand(string caliberName)
        {
            CaliberName = caliberName;
        }
    }
}
