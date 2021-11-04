using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using YogaStudio.Application.Features.Subscriptions.Commands.CreateSubscription;
using YogaStudio.Application.Features.Subscriptions.Commands.DeleteSubscription;
using YogaStudio.Application.Features.Subscriptions.Commands.UpdateSubscription;
using YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionDetails;
using YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionsList;
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
    public class SubscriptionController : BaseController
    {
        private readonly IMapper _mapper;

        public SubscriptionController(IMapper mapper)
        {
            _mapper = mapper;
        }

        /// <summary>
        /// Gets the list of subscriptions
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// GET /subscription
        /// </remarks>
        /// <returns>Returns SubscriptionListVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SubscriptionsListVm>> GetAll()
        {
            var query = new GetSubscriptionsListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Gets the subscription by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// Get /subscription/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Subscription id (guid)</param>
        /// <returns>Return SubscriptionDetailsVm</returns>
        /// <response code="200">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<SubscriptionDetailsVm>> Get(Guid id)
        {
            var query = new GetSubscriptionDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        /// <summary>
        /// Creates the subscription
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// POST /subscription
        /// {
        ///  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///  "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///  "startDate": "2021-11-04T05:39:51.387Z",
        ///  "endDate": "2021-11-04T05:39:51.387Z",
        ///  "numberOfClasses": 0,
        ///  "type": 0
        /// }
        /// </remarks>
        /// <param name="createSubscriptionDto">CreateSubscriptionDto object</param>
        /// <returns>Returns Id (guid)</returns>
        /// <response code="201">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPost]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult<Guid>> Create(
                [FromBody] CreateSubscriptionDto createSubscriptionDto)
        {
            var command = _mapper.Map<CreateSubscriptionCommand>(createSubscriptionDto);
            var subscriptionId = await Mediator.Send(command);
            return Ok(subscriptionId);
        }

        /// <summary>
        /// Updates the subscription
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// PUT /subscription
        ///  {
        ///  "id": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///  "clientId": "3fa85f64-5717-4562-b3fc-2c963f66afa6",
        ///  "classes": "array of the classes",
        ///  "startDate": "2021-11-04T05:39:51.387Z",
        ///  "endDate": "2021-11-04T05:39:51.387Z",
        ///  "numberOfClasses": 0,
        ///  "type": 0,
        ///  "status": 0
        ///  }
        /// </remarks>
        /// <param name="updateSubscriptionDto">UpdateSubscriptionDto object</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpPut]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Update(
                [FromBody] UpdateSubscriptionDto updateSubscriptionDto)
        {
            var command = _mapper.Map<UpdateSubscriptionCommand>(updateSubscriptionDto);
            await Mediator.Send(command);
            return NoContent();
        }

        /// <summary>
        /// Deletes the subscription by id
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// DELETE /subscription/26b88929-d206-4635-8666-ce5cba670874
        /// </remarks>
        /// <param name="id">Subscription id (guid)</param>
        /// <returns>Returns NoContent</returns>
        /// <response code="204">Success</response>
        /// <response code="401">If the user is unatorized</response>
        [HttpDelete("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteSubscriptionCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }
    }
}
