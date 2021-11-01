using System;
using System.Collections.Generic;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;
using MediatR;

namespace YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass
{
    public class UpdateYogaClassCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid MentorId { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int MinClients { get; set; }
        public int MaxClients { get; set; }
        public YogaClassType Type { get; set; }
        public YogaClassStatus Status { get; set; }
    }
}
