using Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Commands.UpdateProgrammingLanguage
{
    public class UpdateProgrammingLanguageCommand:IRequest<UpdateProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public class UpdateProgrammingLanguageHandler : IRequestHandler<UpdateProgrammingLanguageCommand, UpdateProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule _programmingLanguageBusinessRule;

            public UpdateProgrammingLanguageHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRule programmingLanguageBusinessRule)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRule = programmingLanguageBusinessRule;
            }

            public async Task<UpdateProgrammingLanguageDto> Handle(UpdateProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguageUpdated = await _programmingLanguageRepository.GetAsync(x => x.Id == request.Id);
                _programmingLanguageBusinessRule.ProgrammingLanguageShouldExistWhenRequested(programmingLanguageUpdated);
                await _programmingLanguageBusinessRule.ProgrammingLanguageNameCanNotBeDuplicatedWhenInserted(request.Name);

                programmingLanguageUpdated!.Name = request.Name!;
                ProgrammingLanguage updatedProgrammingLanguage = await _programmingLanguageRepository.UpdateAsync(programmingLanguageUpdated);
                UpdateProgrammingLanguageDto updatedProgrammingLanguageDto = _mapper.Map<UpdateProgrammingLanguageDto>(updatedProgrammingLanguage);

                return updatedProgrammingLanguageDto;

            }
        }
    }
}
