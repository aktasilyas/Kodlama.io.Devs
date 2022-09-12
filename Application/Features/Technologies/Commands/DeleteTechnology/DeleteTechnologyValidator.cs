using Application.Features.Technologies.Commands.CreateTechnology;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.DeleteTechnology
{
    public class DeleteTechnologyValidator : AbstractValidator<DeleteTechnologyCommand>
    {
        public DeleteTechnologyValidator()
        {
            RuleFor(c => c.Id).NotEmpty();
        }
    }
}
