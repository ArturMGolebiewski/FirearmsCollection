using AutoMapper;
using MyAPI.Application.Commands;
using MyAPI.Domain.Ammunition.Entities;

namespace MyAPI.Application.Common.MapperProfiles
{
    public sealed class AmmoMappingProfile : Profile
    {
        public AmmoMappingProfile()
        {
            CreateMap<AddAmmunitionCommand, Ammunition>(MemberList.Source);
        }
    }
}
