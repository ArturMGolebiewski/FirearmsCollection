using AutoMapper;
using FluentResults;
using MediatR;
using MyAPI.Application.Common.Interfaces;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Application.Commands.Handlers
{
    public sealed class AddManufacturerCommandHandler : IRequestHandler<AddManufacturerCommand, Result>
    {
        private readonly INewManufacturerWriter _manufacturerWriter;
        private readonly IMapper _mapper;

        public AddManufacturerCommandHandler(INewManufacturerWriter manufacturerWriter, IMapper mapper)
        {
            _manufacturerWriter = manufacturerWriter;
            _mapper = mapper;
        }

        public async Task<Result> Handle(AddManufacturerCommand request, CancellationToken cancellationToken)
        {
            var newManufacturer = _mapper.Map<Manufacturer>(request);
            return await _manufacturerWriter.WriteAsync(newManufacturer, cancellationToken);
        }
    }
}
