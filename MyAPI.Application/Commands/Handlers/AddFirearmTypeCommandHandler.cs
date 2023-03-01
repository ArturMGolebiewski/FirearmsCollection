using AutoMapper;
using FluentResults;
using MediatR;
using MyAPI.Domain.FirearmType.Entities;
using MyAPI.Infrastructure.Firearms;
using MyAPI.Infrastructure.FirearmTypes;

namespace MyAPI.Application.Commands.Handlers
{
    public sealed class AddFirearmTypeCommandHandler : IRequestHandler<AddFirearmTypeCommand, Result>
    {
        private readonly INewFirearmTypeWriter _typeWriter;
        private readonly IMapper _mapper;
        private readonly IFirearmTypesReader _typeReader;

        public AddFirearmTypeCommandHandler(INewFirearmTypeWriter typeWriter, IMapper mapper, IFirearmTypesReader typeReader)
        {
            _typeWriter = typeWriter;
            _mapper = mapper;
            _typeReader = typeReader;
        }

        public async Task<Result>Handle(AddFirearmTypeCommand request, CancellationToken cancellationToken)
        {
            var typeUnique = await _typeReader.CheckIfFirearmTypeUnique(request.Type);
            if (typeUnique.IsFailed)
            {
                return typeUnique;
            }
            var newFirearmType = _mapper.Map<FirearmType>(request);
            return await _typeWriter.WriteFirearmTypeAsync(newFirearmType, cancellationToken);
        }
    }
}
