using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Application.Features.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfClasses { get; set; }
        public SubscriptionType Type { get; set; }
    }
}
