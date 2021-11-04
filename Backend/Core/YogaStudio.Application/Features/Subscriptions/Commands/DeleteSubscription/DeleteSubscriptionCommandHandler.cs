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

namespace YogaStudio.Application.Features.Subscriptions.Commands.DeleteSubscription
{
    public class DeleteSubscriptionCommandHandler
        : IRequestHandler<DeleteSubscriptionCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public DeleteSubscriptionCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteSubscriptionCommand request, 
            CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (subscription == null)
                throw new NotFoundException(nameof(Subscription), request.Id);

            _context.Subscriptions.Remove(subscription);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
