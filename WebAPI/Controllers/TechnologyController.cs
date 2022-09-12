using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Technologies.Commands.CreateTechnology;
using Application.Features.Technologies.Commands.DeleteTechnology;
using Application.Features.Technologies.Commands.UpdateTechnology;
using Application.Features.Technologies.Dtos;
using Application.Features.Technologies.Models;
using Application.Features.Technologies.Queries.GetListTechnology;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TechnologyController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListTechnologyQuery getListTechnologyQuery = new GetListTechnologyQuery { PageRequest = pageRequest };
            TechnologyModel result = await Mediator!.Send(getListTechnologyQuery);
            return Ok(result);
        }
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateTechnologyCommand createTechnologyCommand)
        {
            CreateTechnologyDto result = await Mediator!.Send(createTechnologyCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTechnologyCommand updateTechnologyCommand)
        {
            var result = await Mediator!.Send(updateTechnologyCommand);
            return Created("", result);
        }
        [HttpDelete]
        public async Task<IActionResult> Delete([FromBody] DeleteTechnologyCommand deleteTechnologyCommand)
        {
            var result = await Mediator!.Send(deleteTechnologyCommand);
            return Created("", result);
        }
    }
}
