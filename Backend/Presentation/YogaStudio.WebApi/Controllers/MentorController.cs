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
using YogaStudio.Application.Features.Mentors.Commands.CreateMentor;
using YogaStudio.Application.Features.Mentors.Commands.DeleteMentor;
using YogaStudio.Application.Features.Mentors.Commands.UpdateMentor;
using YogaStudio.Application.Features.Mentors.Queries.GetMentorDetails;
using YogaStudio.Application.Features.Mentors.Queries.GetMentorsList;
using YogaStudio.WebApi.Models;

namespace YogaStudio.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class MentorController : BaseController
    {
        private readonly IMapper _mapper;

        public MentorController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of mentors
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /mentor
        /// </remarks>
        /// <returns>Returns MentorsListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MentorsListVm>> GetAll()
        {
            var query = new GetMentorsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the mentor by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /mentor/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Mentor id (guid)</param>
        /// <returns>Return MentorDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<MentorDetailsVm>> Get(Guid id)
        {
            var query = new GetMentorDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        /// <summary>
        /// Creates a mentor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /mentor
        /// {
        ///     Id: "26b88929-d206-4635-8666-ce5cba670874",
        ///     FirstName: "FirstName of client",
        ///     LastName: "LastName of client",
        ///     PhoneNumber: "+79177457474"
        /// }
        /// </remarks>
        /// <param name="createMentorDto">CreateMentorDto object</param>
        /// <returns>Returns Id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateMentorDto createMentorDto)
        {
            var command = _mapper.Map<CreateMentorCommand>(createMentorDto);
            var mentorId = await Mediator.Send(command);
            return Ok(mentorId);
        }
        /// <summary>
        /// Updates a mentor
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /mentor
        /// {
        ///     Id: "26b88929-d206-4635-8666-ce5cba670874",
        ///     FirstName: "FirstName of client",
        ///     LastName: "LastName of client",
        ///     PhoneNumber: "+79177457474"
        /// }
        /// </remarks>
        /// <param name="updateMentorDto">UpdateMentorDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(
            [FromBody] UpdateMentorDto updateMentorDto)
        {
            var command = _mapper.Map<UpdateMentorCommand>(updateMentorDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes a mentor by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /mentor/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Mentor id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteMentorCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
