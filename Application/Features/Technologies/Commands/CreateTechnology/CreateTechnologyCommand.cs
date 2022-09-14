using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.CreateTechnology
{
    public class CreateTechnologyCommand : IRequest<CreateTechnologyDto>
    {
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public class CreateTechnologyCommandHandler : IRequestHandler<CreateTechnologyCommand, CreateTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRule _technologyBusinessRule;

            public CreateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRule technologyBusinessRule)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRule = technologyBusinessRule;
            }

            public async Task<CreateTechnologyDto> Handle(CreateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRule.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                Technology mappedTechnology = _mapper.Map<Technology>(request);
                Technology createdTechnology = await _technologyRepository.AddAsync(mappedTechnology);
                CreateTechnologyDto createdTechnologyDto = _mapper.Map<CreateTechnologyDto>(createdTechnology);

                return createdTechnologyDto;

            }
        }
    }
}
