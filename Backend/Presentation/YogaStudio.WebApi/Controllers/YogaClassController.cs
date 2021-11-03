﻿using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass;
using YogaStudio.Application.Features.YogaClasses.Commands.DeleteYogaClass;
using YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass;
using YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassDetails;
using YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList;
using YogaStudio.WebApi.Models;

namespace YogaStudio.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class YogaClassController : BaseController
    {
        private readonly IMapper _mapper;

        public YogaClassController(IMapper mapper)
        {
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<YogaClassListVm>> GetAll()
        {
            var query = new GetYogaClassListQuery();
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<YogaClassDetailsVm>> Get(Guid id)
        {
            var query = new GetYogaClassDetailsQuery
            {
                Id = id
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create(
            [FromBody] CreateYogaClassDto createYogaClassDto)
        {
            var command = _mapper.Map<CreateYogaClassCommand>(createYogaClassDto);
            var yogaClassId = await Mediator.Send(command);
            return Ok(yogaClassId);
        }

        [HttpPut]
        public async Task<IActionResult> Update(
            [FromBody] UpdateYogaClassDto updateYogaClassDto)
        {
            var command = _mapper.Map<UpdateYogaClassCommand>(updateYogaClassDto);
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
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