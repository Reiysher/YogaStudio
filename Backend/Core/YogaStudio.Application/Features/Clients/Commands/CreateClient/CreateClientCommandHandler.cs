using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandHandler
        : IRequestHandler<CreateClientCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public CreateClientCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateClientCommand request,
            CancellationToken cancellationToken)
        {
            var client = new Client
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Subscriptions = new List<Subscription>()
            };

            await _context.Clients.AddAsync(client, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
