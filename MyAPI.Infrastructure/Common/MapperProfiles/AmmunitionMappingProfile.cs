using AutoMapper;
using MyAPI.Infrastructure.Database.Entities;

namespace MyAPI.Infrastructure.Common.MapperProfiles
{
    public sealed class AmmunitionMappingProfile : Profile
    {
        public AmmunitionMappingProfile()
        {
            CreateMap<Ammunition, Domain.Ammunition.Entities.Ammunition>(MemberList.Destination);
            CreateMap<Domain.Ammunition.Entities.Ammunition, Ammunition>(MemberList.Source);
        }
    }
}
