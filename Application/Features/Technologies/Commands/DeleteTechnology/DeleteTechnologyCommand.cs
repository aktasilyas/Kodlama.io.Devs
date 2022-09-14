using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Rules;
using Application.Services.Repositories;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyCommand:IRequest<DeleteTechnologyDto>
    {
        public int Id { get; set; }

        public class DeleteTechnologyCommandHandler : IRequestHandler<DeleteTechnologyCommand, DeleteTechnologyDto>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;
            private readonly TechnologyBusinessRule _technologyBusinessRule;

            public DeleteTechnologyCommandHandler(ITechnologyRepository technologyRepository, IMapper mapper, TechnologyBusinessRule technologyBusinessRule)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
                _technologyBusinessRule = technologyBusinessRule;
            }

            public async Task<DeleteTechnologyDto> Handle(DeleteTechnologyCommand request, CancellationToken cancellationToken)
            {
                var result = await _technologyRepository.GetAsync(x => x.Id == request.Id);
                _technologyBusinessRule.TechnologyShouldExistWhenRequested(result);

                var deletedTechnology = await _technologyRepository.DeleteAsync(result);
                var mappedTechnologyDto =  _mapper.Map<DeleteTechnologyDto>(deletedTechnology);
                return mappedTechnologyDto; ;
            }
        }
    }
}
