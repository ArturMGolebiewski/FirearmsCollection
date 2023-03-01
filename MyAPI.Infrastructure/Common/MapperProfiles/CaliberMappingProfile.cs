using AutoMapper;
using MyAPI.Infrastructure.Database.Entities;

namespace MyAPI.Infrastructure.Common.MapperProfiles
{
    public sealed class CaliberMappingProfile : Profile
    {
        public CaliberMappingProfile()
        {
            CreateMap<Caliber, Domain.Caliber.Entities.Caliber>(MemberList.Destination);
            CreateMap<Domain.Caliber.Entities.Caliber, Caliber>(MemberList.Source);
        }
    }
}
