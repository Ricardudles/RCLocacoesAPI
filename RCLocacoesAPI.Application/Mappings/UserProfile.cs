using AutoMapper;
using RCLocacoes.Application.DTOs;
using RCLocacoes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RCLocacoes.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(prop => prop.Password, map => map.MapFrom(src => src.PasswordHash)).ReverseMap();
        }
    }
}
