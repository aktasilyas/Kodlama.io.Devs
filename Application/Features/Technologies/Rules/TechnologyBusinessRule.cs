using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Rules
{
    public class TechnologyBusinessRule
    {
        private readonly ITechnologyRepository _technologyRepository;

        public TechnologyBusinessRule(ITechnologyRepository technologyRepository)
        {
            _technologyRepository = technologyRepository;
        }
        public async Task TechnologyNameCanNotBeDuplicatedWhenInserted(string name)
        {
            IPaginate<Technology> result = await _technologyRepository.GetListAsync(b => b.Name == name);
            if (result.Items.Any()) throw new BusinessException("Technology  exists.");
        }

        public void TechnologyShouldExistWhenRequested(Technology technology)
        {
            if (technology == null) throw new BusinessException("Requested Technology does not exist");
        }
    }
}
