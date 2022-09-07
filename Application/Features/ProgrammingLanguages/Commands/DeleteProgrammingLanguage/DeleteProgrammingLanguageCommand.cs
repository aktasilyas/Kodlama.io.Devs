using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
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

namespace Application.Features.ProgrammingLanguages.Commands.DeleteProgrammingLanguage
{
    public class DeleteProgrammingLanguageCommand:IRequest<DeleteProgrammingLanguageDto>
    {
        public int Id { get; set; }
        public class DeleteProgrammingLanguageHandler : IRequestHandler<DeleteProgrammingLanguageCommand, DeleteProgrammingLanguageDto>
        {
            private readonly IProgrammingLanguageRepository _programmingLanguageRepository;
            private readonly IMapper _mapper;
            private readonly ProgrammingLanguageBusinessRule _programmingLanguageBusinessRule;

            public DeleteProgrammingLanguageHandler(IProgrammingLanguageRepository programmingLanguageRepository, IMapper mapper, ProgrammingLanguageBusinessRule programmingLanguageBusinessRule)
            {
                _programmingLanguageRepository = programmingLanguageRepository;
                _mapper = mapper;
                _programmingLanguageBusinessRule = programmingLanguageBusinessRule;
            }

            public async Task<DeleteProgrammingLanguageDto> Handle(DeleteProgrammingLanguageCommand request, CancellationToken cancellationToken)
            {
                ProgrammingLanguage? programmingLanguageDeleted=await _programmingLanguageRepository.GetAsync(x=>x.Id==request.Id);
                 _programmingLanguageBusinessRule.ProgrammingLanguageShouldExistWhenRequested(programmingLanguageDeleted);

                ProgrammingLanguage deleteddProgrammingLanguage = await _programmingLanguageRepository.DeleteAsync(programmingLanguageDeleted);
                DeleteProgrammingLanguageDto deletedProgrammingLanguageDto = _mapper.Map<DeleteProgrammingLanguageDto>(deleteddProgrammingLanguage);

                return deletedProgrammingLanguageDto;

            }
        }
    }
}
