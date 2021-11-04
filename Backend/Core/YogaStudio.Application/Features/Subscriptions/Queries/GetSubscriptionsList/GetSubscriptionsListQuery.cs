using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionsList
{
    //TODO: Use userId for query
    public class GetSubscriptionsListQuery : IRequest<SubscriptionsListVm>
    {
    }
}
