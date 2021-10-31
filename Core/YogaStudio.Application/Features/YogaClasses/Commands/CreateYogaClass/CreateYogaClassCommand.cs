using System;
using MediatR;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass
{
    public class CreateYogaClassCommand : IRequest<Guid>
    {
        public Guid MentorId { get; set; }
        public DateTime StartDate { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinClients { get; set; }
        public int MaxClients { get; set; }
        public YogaClassType Type { get; set; }
    }
}
