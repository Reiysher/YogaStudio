using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Subscriptions.Commands.UpdateSubscription
{
    public class UpdateSubscriptionCommandHandler
        : IRequestHandler<UpdateSubscriptionCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public UpdateSubscriptionCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateSubscriptionCommand request, 
            CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (subscription == null)
                throw new NotFoundException(nameof(Subscription), request.Id);

            subscription.Id = request.Id;
            subscription.ClientId = request.ClientId;
            subscription.Classes = request.Classes;
            subscription.StartDate = request.StartDate;
            subscription.EndDate = request.EndDate;
            subscription.NumberOfClasses = request.NumberOfClasses;
            subscription.Type = request.Type;
            subscription.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
