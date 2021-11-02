using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YogaStudio.Application.Features.Clients.Commands.CreateClient;
using YogaStudio.Application.Features.Clients.Commands.DeleteClient;
using YogaStudio.Application.Features.Clients.Commands.UpdateClient;
using YogaStudio.Application.Features.Clients.Queries.GetClientDetails;
using YogaStudio.Application.Features.Clients.Queries.GetClientsList;
using YogaStudio.WebApi.Models;

namespace YogaStudio.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;

        public ClientController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<ClientsListVm>> GetAll()
        {
            var query = new GetClientsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ClientDetailsVm>> Get(Guid id)
        {
            var query = new GetClientDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateClientDto createClientDto)
        {
            var command = _mapper.Map<CreateClientCommand>(createClientDto);
            var clientId = await Mediator.Send(command);
            return Ok(clientId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateClientDto updateClientDto)
        {
            var command = _mapper.Map<UpdateClientCommand>(updateClientDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteClientCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
