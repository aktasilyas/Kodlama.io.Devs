﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ProgrammingLanguages.Dtos
{
    public class UpdateTechnologyDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LanguageId { get; set; }
    }
}
