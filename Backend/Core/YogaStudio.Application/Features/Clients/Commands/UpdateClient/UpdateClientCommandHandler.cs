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

namespace YogaStudio.Application.Features.Clients.Commands.UpdateClient
{
    public class UpdateClientCommandHandler
        : IRequestHandler<UpdateClientCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public UpdateClientCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (client == null)
                throw new NotFoundException(nameof(Client), request.Id);

            client.Id = request.Id;
            client.FirstName = request.FirstName;
            client.LastName = request.LastName;
            client.PhoneNumber = request.PhoneNumber;
            client.Subscriptions = request.Subscriptions;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
