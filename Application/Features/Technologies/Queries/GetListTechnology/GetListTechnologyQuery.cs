using Application.Features.Technologies.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Queries.GetListTechnology
{
    public class GetListTechnologyQuery:IRequest<TechnologyModel>
    {
        public PageRequest PageRequest { get; set; }

        public class GetListTechnologyQueryHandler : IRequestHandler<GetListTechnologyQuery, TechnologyModel>
        {
            private readonly ITechnologyRepository _technologyRepository;
            private readonly IMapper _mapper;

            public GetListTechnologyQueryHandler(ITechnologyRepository technologyRepository, IMapper mapper)
            {
                _technologyRepository = technologyRepository;
                _mapper = mapper;
            }

            public async Task<TechnologyModel> Handle(GetListTechnologyQuery request, CancellationToken cancellationToken)
            {
               IPaginate<Technology> technologies=await _technologyRepository.GetListAsync(include:
                    m => m.Include(c => c.Language),
                    index: request.PageRequest.Page,
                    size: request.PageRequest.PageSize);


                TechnologyModel mappedTechnology = _mapper.Map<TechnologyModel>(technologies);
                return mappedTechnology;
            }
        }
    }
}
