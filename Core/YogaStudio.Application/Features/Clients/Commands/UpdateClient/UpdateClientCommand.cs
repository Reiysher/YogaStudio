using MediatR;
using System;
using System.Collections.Generic;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public IEnumerable<Subscription> Subscriptions { get; set; }
    }
}
