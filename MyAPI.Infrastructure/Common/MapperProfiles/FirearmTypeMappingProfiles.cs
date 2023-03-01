using AutoMapper;
using MyAPI.Infrastructure.Database.Entities;

namespace MyAPI.Infrastructure.Common.MapperProfiles
{
    public sealed class FirearmTypeMappingProfiles : Profile
    {
        public FirearmTypeMappingProfiles()
        {
            CreateMap<FirearmType, Domain.FirearmType.Entities.FirearmType>(MemberList.Destination);
            CreateMap<Domain.FirearmType.Entities.FirearmType, FirearmType>(MemberList.Source);
        }
    }
}
