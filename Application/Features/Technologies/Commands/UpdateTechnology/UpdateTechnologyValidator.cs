using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Technologies.Commands.UpdateTechnology
{
    public class UpdateTechnologyValidator : AbstractValidator<UpdateTechnologyCommand>
    {
        public UpdateTechnologyValidator()
        {
            RuleFor(c => c.Name).NotEmpty();
            RuleFor(c => c.LanguageId).NotEmpty();
            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
