using AutoMapper;
using MyAPI.Application.Commands;
using MyAPI.Domain.Firearm.Entities;

namespace MyAPI.Application.Common.MapperProfiles
{
    public sealed class FirearmMappingProfile : Profile
    {
        public FirearmMappingProfile()
        {
            CreateMap<AddFirearmCommand, Firearm>(MemberList.Source);
        }
    }
}
