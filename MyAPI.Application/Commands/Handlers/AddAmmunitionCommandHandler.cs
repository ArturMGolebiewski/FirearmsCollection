using AutoMapper;
using FluentResults;
using MediatR;
using MyAPI.Domain.Ammunition.Entities;
using MyAPI.Infrastructure.Ammo;

namespace MyAPI.Application.Commands.Handlers
{
    public sealed class AddAmmunitionCommandHandler : IRequestHandler<AddAmmunitionCommand, Result>
    {
        private readonly IAmmoReader _ammoReader;
        private readonly INewAmmoWriter _ammoWriter;
        private readonly IMapper _mapper;
        public AddAmmunitionCommandHandler(IAmmoReader ammoReader, INewAmmoWriter ammoWriter, IMapper mapper)
        {
            _ammoReader = ammoReader;
            _ammoWriter = ammoWriter;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddAmmunitionCommand request, CancellationToken cancellationToken)
        {
            var nameUnique = await _ammoReader.CheckIfAmmoNameUnique(request.CaliberId);
            if (nameUnique.IsFailed)
            {
                return nameUnique;
            }
            var newAmmo = _mapper.Map<Ammunition>(request);
            return await _ammoWriter.WriteAsync(newAmmo, cancellationToken);
        }
    }
}
