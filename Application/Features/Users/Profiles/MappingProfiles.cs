using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.RegisterUser;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<User, LoginUserCommand>().ReverseMap();
            CreateMap<User, RegisterUserCommand>().ReverseMap();
        }
    }
}
