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

namespace YogaStudio.Application.Features.Mentors.Commands.DeleteMentor
{
    public class DeleteMentorCommandHandler
        : IRequestHandler<DeleteMentorCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public DeleteMentorCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteMentorCommand request, 
            CancellationToken cancellationToken)
        {
            var mentor = await _context.Mentors
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (mentor == null)
                throw new NotFoundException(nameof(Mentor), request.Id);

            _context.Mentors.Remove(mentor);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
