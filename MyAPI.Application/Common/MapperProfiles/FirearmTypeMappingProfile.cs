using AutoMapper;
using MyAPI.Application.Commands;
using MyAPI.Domain.FirearmType.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyAPI.Application.Common.MapperProfiles
{
    public sealed class FirearmTypeMappingProfile : Profile
    {
        public FirearmTypeMappingProfile()
        {
            CreateMap<AddFirearmTypeCommand, FirearmType>(MemberList.Source);
        }
    }
}
