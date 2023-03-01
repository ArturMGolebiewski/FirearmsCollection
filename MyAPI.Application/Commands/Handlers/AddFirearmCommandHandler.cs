using AutoMapper;
using FluentResults;
using MediatR;
using MyAPI.Domain.Firearm.Entities;
using MyAPI.Infrastructure.Firearms;

namespace MyAPI.Application.Commands.Handlers
{
    public sealed class AddFirearmCommandHandler : IRequestHandler<AddFirearmCommand, Result>
    {
        private readonly INewFirearmWriter _firearmWriter;
        private readonly IMapper _mapper;
        private readonly IFirearmsReader _firearmsReader;

        public AddFirearmCommandHandler(INewFirearmWriter firearmWriter, IMapper mapper, IFirearmsReader firearmsReader)
        {
            _firearmWriter = firearmWriter;
            _mapper = mapper;
            _firearmsReader = firearmsReader;
        }

        public async Task<Result> Handle(AddFirearmCommand request, CancellationToken cancellationToken)
        {
            var nameUnique = await _firearmsReader.CheckIfFirearmNameUnique(request.FirearmModelName);
            if (nameUnique.IsFailed)
            {
                return nameUnique;
            }
            var newFirearm = _mapper.Map<Firearm>(request);
            return await _firearmWriter.WriteFirearmAsync(newFirearm, cancellationToken);
        }
    }
}
