using AutoMapper;
using DatabaseManufacturer = MyAPI.Infrastructure.Database.Entities.Manufacturer;

namespace MyAPI.Infrastructure.Common.MapperProfiles
{
    public sealed class ManufacturerMappingProfile : Profile
    {
        public ManufacturerMappingProfile()
        {
            CreateMap<DatabaseManufacturer, Domain.Manufacturer.Entities.Manufacturer>(MemberList.Destination);
            CreateMap<Domain.Manufacturer.Entities.Manufacturer, DatabaseManufacturer>(MemberList.Source);
        }
    }
}
