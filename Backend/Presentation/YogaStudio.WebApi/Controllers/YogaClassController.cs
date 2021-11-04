using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass;
using YogaStudio.Application.Features.YogaClasses.Commands.DeleteYogaClass;
using YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass;
using YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassDetails;
using YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList;
using YogaStudio.WebApi.Models;

namespace YogaStudio.WebApi.Controllers
{
    [ApiVersionNeutral]
    [Produces("application/json")]
    [Route("api/{version:apiVersion}/[controller]")]
    public class YogaClassController : BaseController
    {
        private readonly IMapper _mapper;

        public YogaClassController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of classes
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /yogaclass
        /// </remarks>
        /// <returns>Returns YogaClassListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<YogaClassListVm>> GetAll()
        {
            var query = new GetYogaClassListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the Class by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /yogaclass/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Class id (guid)</param>
        /// <returns>Return YogaClassDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<YogaClassDetailsVm>> Get(Guid id)
        {
            var query = new GetYogaClassDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the class
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /yogaclass
        /// {
        ///     MentorId: "26b88929-d206-4635-8666-ce5cba670874",
        ///     Date: "04.11.2021",
        ///     Title: "Yoga",
        ///     Description: "...",
        ///     MinClients: "3",
        ///     MaxClients: "12",
        ///     Type: "Online"
        /// }
        /// </remarks>
        /// <param name="createYogaClassDto">CreateYogaClassDto object</param>
        /// <returns>Returns Id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateYogaClassDto createYogaClassDto)
        {
            var command = _mapper.Map<CreateYogaClassCommand>(createYogaClassDto);
            var yogaClassId = await Mediator.Send(command);
            return Ok(yogaClassId);
        }

        /// <summary>
        /// Updates the class
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /yogaclass
        /// {
        ///     MentorId: "26b88929-d206-4635-8666-ce5cba670874",
        ///     Date: "04.11.2021",
        ///     Title: "Yoga",
        ///     Description: "...",
        ///     MinClients: "3",
        ///     MaxClients: "12",
        ///     Type: "Online"
        /// }
        /// </remarks>
        /// <param name="updateYogaClassDto">UpdateYogaClassDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(
            [FromBody] UpdateYogaClassDto updateYogaClassDto)
        {
            var command = _mapper.Map<UpdateYogaClassCommand>(updateYogaClassDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the class by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /yogaclass/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Class id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteYogaClassCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
