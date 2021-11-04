using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Application.Features.Subscriptions.Commands.UpdateSubscription
{
    public class UpdateSubscriptionCommand : IRequest
    {
        public Guid Id { get; set; }
        public Guid ClientId { get; set; }
        public IEnumerable<YogaClass> Classes { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int NumberOfClasses { get; set; }
        public SubscriptionType Type { get; set; }
        public SubscriptionStatus Status { get; set; }
    }
}
