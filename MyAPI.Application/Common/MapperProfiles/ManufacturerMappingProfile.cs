using AutoMapper;
using MyAPI.Application.Commands;
using MyAPI.Domain.Manufacturer.Entities;

namespace MyAPI.Application.Common.MapperProfiles
{
    public sealed class ManufacturerMappingProfile : Profile
    {
        public ManufacturerMappingProfile()
        {
            CreateMap<AddManufacturerCommand, Manufacturer>(MemberList.Source);
        }
    }
}
