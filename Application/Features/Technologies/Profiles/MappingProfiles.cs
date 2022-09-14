using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Models;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Technology, CreateTechnologyDto>().ReverseMap();
            CreateMap<Technology, CreateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, TechnologyDto>().ForMember(c => c.LanguageName, opt => opt.MapFrom(c => c.Language.Name)).ReverseMap();
            CreateMap<IPaginate<Technology>, TechnologyModel>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyCommand>().ReverseMap();
            CreateMap<Technology, UpdateTechnologyDto>().ReverseMap();

            CreateMap<Technology, DeleteTechnologyCommand>().ReverseMap();
            CreateMap<Technology, DeleteTechnologyDto>().ReverseMap();

        }
    }
}
