using AutoMapper;
using MyAPI.Infrastructure.Database.Entities;

namespace MyAPI.Infrastructure.Common.MapperProfiles
{
    public sealed class FirearmMappingProfile : Profile
    {
        public FirearmMappingProfile()
        {
            CreateMap<Firearm, Domain.Firearm.Entities.Firearm>(MemberList.Destination);
            CreateMap<Domain.Firearm.Entities.Firearm, Firearm>(MemberList.Source);
        }
    }
}
