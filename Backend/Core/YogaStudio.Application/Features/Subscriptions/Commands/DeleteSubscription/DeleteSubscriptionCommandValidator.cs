using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandValidator : AbstractValidator<DeleteSubscriptionCommand>
    {
        public DeleteSubscriptionCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
