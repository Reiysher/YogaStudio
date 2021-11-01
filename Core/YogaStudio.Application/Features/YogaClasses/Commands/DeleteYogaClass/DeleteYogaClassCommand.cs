using MediatR;
using System;

namespace YogaStudio.Application.Features.YogaClasses.Commands.DeleteYogaClass
{
    public class DeleteYogaClassCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
