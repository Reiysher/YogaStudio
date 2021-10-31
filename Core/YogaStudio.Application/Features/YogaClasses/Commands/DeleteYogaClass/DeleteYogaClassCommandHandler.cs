using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.YogaClasses.Commands.DeleteYogaClass
{
    public class DeleteYogaClassCommandHandler
        : IRequestHandler<DeleteYogaClassCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public DeleteYogaClassCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(DeleteYogaClassCommand request, 
            CancellationToken cancellationToken)
        {
            var entity = await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(YogaClass), request.Id);

            _context.Classes.Remove(entity);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
