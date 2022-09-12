using Application.Features.UserSocialMediaAddress.Dtos;
using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserSocialMediaAddress.Commands.CreateSocialMediaAddress
{
    public class CreateUserSocialMediaAddressCommand : IRequest<CreateSocialMediaAddressDto>, ISecuredRequest
    {
        public int Id { get; set; }
        public string GithubUrl { get; set; }
        public string[] Roles { get; } = { "User" };

        public class CreateUserSocialMediaAddressCommandHandler : IRequestHandler<CreateUserSocialMediaAddressCommand, CreateSocialMediaAddressDto>
        {
            public async Task<CreateSocialMediaAddressDto> Handle(CreateUserSocialMediaAddressCommand request, CancellationToken cancellationToken)
            {
                
            }
        }

    }
}
