using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Subscriptions.Commands.CreateSubscription
{
    public class CreateSubscriptionCommandHandler
        : IRequestHandler<CreateSubscriptionCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public CreateSubscriptionCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateSubscriptionCommand request, 
            CancellationToken cancellationToken)
        {
            var subscription = new Subscription
            {
                Id = request.Id,
                ClientId = request.ClientId,
                Classes = new List<YogaClass>(),
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                NumberOfClasses = request.NumberOfClasses,
                Type = request.Type,
                Status = Domain.Enums.SubscriptionStatus.Active
            };

            await _context.Subscriptions.AddAsync(subscription, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
