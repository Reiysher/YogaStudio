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

namespace YogaStudio.Application.Features.Mentors.Commands.UpdateMentor
{
    public class UpdateMentorCommandHandler
        : IRequestHandler<UpdateMentorCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public UpdateMentorCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateMentorCommand request, 
            CancellationToken cancellationToken)
        {
            var mentor = await _context.Mentors
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (mentor == null)
                throw new NotFoundException(nameof(Mentor), request.Id);

            mentor.Id = request.Id;
            mentor.FirstName = request.FirstName;
            mentor.LastName = request.LastName;
            mentor.PhoneNumber = request.PhoneNumber;
            mentor.Classes = request.Classes;

            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
