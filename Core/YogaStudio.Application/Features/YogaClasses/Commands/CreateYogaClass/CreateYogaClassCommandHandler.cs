using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;
using YogaStudio.Domain.Enums;

namespace YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass
{
    public class CreateYogaClassCommandHandler
        : IRequestHandler<CreateYogaClassCommand, Guid>
    {
        private readonly IYogaStudioDbContext _context;
        public CreateYogaClassCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreateYogaClassCommand request, 
            CancellationToken cancellationToken)
        {
            var yogaClass = new YogaClass
            {
                Id = Guid.NewGuid(),
                MentorId = request.MentorId,
                StartDate = request.StartDate,
                Description = request.Description,
                MinClients = request.MinClients,
                MaxClients = request.MaxClients,
                Type = request.Type,
                Status = YogaClassStatus.Planned,
                Subscriptions = new List<Subscription>()
            };

            await _context.Classes.AddAsync(yogaClass, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return yogaClass.Id;
        }
    }
}
