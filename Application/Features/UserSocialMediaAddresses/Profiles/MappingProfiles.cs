using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.UserSocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Application.Features.UserSocialMediaAddresses.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Profiles
{
    public class MappingProfiles:Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserSocialMediaAddress, CreateSocialMediaAddressDto>().ReverseMap();
            CreateMap<UserSocialMediaAddress, CreateUserSocialMediaAddressCommand>().ReverseMap();
        }
    }
}
