using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionDetails
{
    public class GetSubscriptionDetailsQueryValidator : AbstractValidator<GetSubscriptionDetailsQuery>
    {
        public GetSubscriptionDetailsQueryValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
