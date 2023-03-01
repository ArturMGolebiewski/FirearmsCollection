using AutoMapper;
using MyAPI.Application.Commands;
using MyAPI.Domain.Caliber.Entities;

namespace MyAPI.Application.Common.MapperProfiles
{
    public sealed class CaliberMappingProfile : Profile
    {
        public CaliberMappingProfile()
        {
            CreateMap<AddCaliberCommand, Caliber>(MemberList.Source);
        }
    }
}
