using AutoMapper;
using FluentResults;
using MediatR;
using MyAPI.Domain.Caliber.Entities;
using MyAPI.Infrastructure.Calibers;

namespace MyAPI.Application.Commands.Handlers
{
    public sealed class AddCaliberCommandHandler : IRequestHandler<AddCaliberCommand, Result>
    {
        private readonly INewCaliberWriter _caliberWriter;
        private readonly IMapper _mapper;
        private readonly ICaliberReader _caliberReader;

        public AddCaliberCommandHandler(INewCaliberWriter caliberWriter, IMapper mapper, ICaliberReader caliberReader)
        {
            _caliberWriter = caliberWriter;
            _mapper = mapper;
            _caliberReader = caliberReader;
        }

        public async Task<Result> Handle(AddCaliberCommand request, CancellationToken cancellationToken)
        {
            var nameUnique = await _caliberReader.CheckIfCaliberNameUnique(request.CaliberName);
            if (nameUnique.IsFailed)
            {
                return nameUnique;
            }
            var newCaliber = _mapper.Map<Caliber>(request);
            return await _caliberWriter.WriteCaliberAsync(newCaliber, cancellationToken);
        }
    }
}
