using Application.Features.UserSocialMediaAddresses.Dtos;
using Application.Features.UserSocialMediaAddresses.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Pipelines.Authorization;
using Core.Security.Extensions;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddresses.Commands.CreateSocialMediaAddress
{
    public class CreateUserSocialMediaAddressCommand : IRequest<CreateSocialMediaAddressDto>, ISecuredRequest
    {
        public string GithubUrl { get; set; }
        public string[] Roles { get; } = { "User" };

        public class CreateUserSocialMediaAddressCommandHandler : IRequestHandler<CreateUserSocialMediaAddressCommand, CreateSocialMediaAddressDto>
        {
            private readonly IUserSocialMediaAddressRepository _userSocialMediaAddressRepository;
            private readonly IMapper _mapper;
            private readonly IHttpContextAccessor _httpContextAccessor;
            private readonly UserSocialMediaAddressBusinessRule _userSocialMediaAddressBusinessRule;

            public CreateUserSocialMediaAddressCommandHandler(IUserSocialMediaAddressRepository userSocialMediaAddressRepository, IMapper mapper, UserSocialMediaAddressBusinessRule userSocialMediaAddressBusinessRule, IHttpContextAccessor httpContextAccessor)
            {
                _userSocialMediaAddressRepository = userSocialMediaAddressRepository;
                _mapper = mapper;
                _userSocialMediaAddressBusinessRule = userSocialMediaAddressBusinessRule;
                _httpContextAccessor = httpContextAccessor;
            }

            public async Task<CreateSocialMediaAddressDto> Handle(CreateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                var userId = _httpContextAccessor.HttpContext.User.GetUserId();
                await _userSocialMediaAddressBusinessRule.UserSocialMediaAddressGithubUrlCanNotBeDuplicated(request.GithubUrl);
                await _userSocialMediaAddressBusinessRule.UserMustBeExist(userId);
                await _userSocialMediaAddressBusinessRule.UserSocialMediaAddressCanNotHaveMoreThanOneGithubAddress(userId);

                var mappedUserSocialMediaAddress = _mapper.Map<UserSocialMediaAddress>(request);
                mappedUserSocialMediaAddress.UserId = userId;
                var createdUserSocialMediaAddress = await _userSocialMediaAddressRepository.AddAsync(mappedUserSocialMediaAddress);
                var mappedCreatedUserSocialMediaAddressDto = _mapper.Map<CreateSocialMediaAddressDto>(createdUserSocialMediaAddress);
                return mappedCreatedUserSocialMediaAddressDto;
            }
        }

    }
}
