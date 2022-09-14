using Application.Features.Users.Rules;
using Application.Services.Repositories;
using Core.Security.JWT;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<AccessToken>
    {
        public string Email { get; set; }
        public string Password { get; set; }

        /// <summary>
        /// Kullanıcılar giriş yapmak için kullanılan işleyici sınıfıdır.
        /// </summary>
        public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, AccessToken>
        {
            private readonly IUserRepository _userRepository;
            private readonly UserBusinessRules _userBusinessRules;
            private readonly ITokenHelper _tokenHelper;
            private readonly IUserOperationClaimRepository _userOperationClaimRepository;

            public LoginUserCommandHandler(IUserRepository userRepository, UserBusinessRules userBusinessRules, ITokenHelper tokenHelper, IUserOperationClaimRepository userOperationClaimRepository)
            {
                _userRepository = userRepository;
                _userBusinessRules = userBusinessRules;
                _tokenHelper = tokenHelper;
                _userOperationClaimRepository = userOperationClaimRepository;
            }

            public async Task<AccessToken> Handle(LoginUserCommand request, CancellationToken cancellationToken)
            {
                var user = await _userRepository.GetAsync(x => x.Email == request.Email);

                _userBusinessRules.CheckIfUserExists(user);
                _userBusinessRules.CheckIfPasswordIsCorrect(request.Password, user.PasswordHash, user.PasswordSalt);

                var userClaims = await _userOperationClaimRepository.GetListAsync(x =>
                        x.UserId == user.Id,
                    include: x => x.Include(c => c.OperationClaim),
                    cancellationToken: cancellationToken);

                var accessToken = _tokenHelper.CreateToken(user, userClaims.Items.Select(x => x.OperationClaim).ToList());

                return accessToken;
            }
        }
    }
}
