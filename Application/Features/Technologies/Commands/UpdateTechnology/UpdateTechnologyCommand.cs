using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyCommand:IRequest<UpdateTechnologyDto>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
        public class UpdateTechnologyCommandHandler : IRequestHandler<UpdateTechnologyCommand, UpdateTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRule _technologyBusinessRule;

            public UpdateTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRule technologyBusinessRule)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRule = technologyBusinessRule;
            }

           public async Task<UpdateTechnologyDto> Handle(UpdateTechnologyCommand request, CancellationToken cancellationToken)
            {
                await _technologyBusinessRule.TechnologyNameCanNotBeDuplicatedWhenInserted(request.Name);

                var programmingLanguageTechnology = await _technologyRepository.Query().AsNoTracking().FirstOrDefaultAsync(x =>
                    x.Id == request.Id,
                    cancellationToken: cancellationToken);

                 _technologyBusinessRule.TechnologyShouldExistWhenRequested(programmingLanguageTechnology);
                var mappedProgrammingLanguageTechnology = _mapper.Map<Technology>(request);
                var updatedProgrammingLanguageTechnology = await _technologyRepository.UpdateAsync(mappedProgrammingLanguageTechnology);
                var mappedProgrammingLanguageTechnologyDto = _mapper.Map<UpdateTechnologyDto>(updatedProgrammingLanguageTechnology);
                return mappedProgrammingLanguageTechnologyDto;
            }
        }
    }
}
