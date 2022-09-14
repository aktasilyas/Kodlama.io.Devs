﻿using Application.Features.Users.Constants;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandValidator : AbstractValidator<LoginUserCommand>
    {
        public LoginUserCommandValidator()
        {
            RuleFor(p => p.Email)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserMessages.EmailAddressIsRequired)
                .EmailAddress().WithMessage(UserMessages.EmailAddressIsNotValid);

            RuleFor(p => p.Password)
                .NotEmpty()
                .NotNull()
                .WithMessage(UserMessages.PasswordIsRequired);
        }
    }
}
