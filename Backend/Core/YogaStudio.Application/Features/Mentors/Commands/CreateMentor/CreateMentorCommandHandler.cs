using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.Mentors.Commands.CreateMentor
{
    public class CreateMentorCommandHandler
        : IRequestHandler<CreateMentorCommand>
    {
        private readonly IYogaStudioDbContext _context;

        public CreateMentorCommandHandler(IYogaStudioDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(CreateMentorCommand request, 
            CancellationToken cancellationToken)
        {
            var mentor = new Mentor
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PhoneNumber = request.PhoneNumber,
                Classes = new List<YogaClass>()
            };

            await _context.Mentors.AddAsync(mentor, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
