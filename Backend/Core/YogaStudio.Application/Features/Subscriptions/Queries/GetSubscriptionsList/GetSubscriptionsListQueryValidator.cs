using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionsList
{
    public class GetSubscriptionsListQueryValidator : AbstractValidator<GetSubscriptionsListQuery>
    {
        public GetSubscriptionsListQueryValidator()
        {
            // empty
        }
    }
}
