using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;

        public ClientController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of clients
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /client
        /// </remarks>
        /// <returns>Returns ClientsListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ClientsListVm>> GetAll()
        {
            var query = new GetClientsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the client by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /client/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Client id (guid)</param>
        /// <returns>Return ClientDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<ClientDetailsVm>> Get(Guid id)
        {
            var query = new GetClientDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        /// <summary>
        /// Creates a client
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /client
        /// {
        ///     Id: "26b88929-d206-4635-8666-ce5cba670874",
        ///     FirstName: "FirstName of client",
        ///     LastName: "LastName of client",
        ///     PhoneNumber: "+79177457474"
        /// }
        /// </remarks>
        /// <param name="createClientDto">CreateClientDto object</param>
        /// <returns>Returns Id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateClientDto createClientDto)
        {
            var command = _mapper.Map<CreateClientCommand>(createClientDto);
            var clientId = await Mediator.Send(command);
            return Ok(clientId);
        }
        /// <summary>
        /// Updates a client
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /client
        /// {
        ///     Id: "26b88929-d206-4635-8666-ce5cba670874",
        ///     FirstName: "FirstName of client",
        ///     LastName: "LastName of client",
        ///     PhoneNumber: "+79177457474"
        /// }
        /// </remarks>
        /// <param name="updateClientDto">UpdateClientDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(
            [FromBody] UpdateClientDto updateClientDto)
        {
            var command = _mapper.Map<UpdateClientCommand>(updateClientDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes a client by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /client/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Client id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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
