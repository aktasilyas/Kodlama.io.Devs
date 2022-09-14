using Application.Features.UserSocialMediaAddresses.Commands.CreateSocialMediaAddress;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediaAddressesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateUserSocialMediaAddressCommand createUserSocialMediaAddressCommand)
        {
            var result = await Mediator!.Send(createUserSocialMediaAddressCommand);
            return Created("", result);
        }
    }
}
