using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionDetails
{
    public class GetSubscriptionDetailsQuery : IRequest<SubscriptionDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
