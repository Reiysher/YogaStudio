using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass
{
    public class UpdateYogaClassCommandHandler
        : IRequestHandler<UpdateYogaClassCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public UpdateYogaClassCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async  Task<Unit> Handle(UpdateYogaClassCommand request, 
            CancellationToken cancellationToken)
        {
            var entity = await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(YogaClass), request.Id);

            entity.MentorId = request.MentorId;
            entity.Subscriptions = request.Subscriptions;
            entity.Date = request.StartDate;
            entity.Title = request.Title;
            entity.Description = request.Description;
            entity.MinClients = request.MinClients;
            entity.MaxClients = request.MaxClients;
            entity.Type = request.Type;
            entity.Status = request.Status;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
