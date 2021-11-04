using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
