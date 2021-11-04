using AutoMapper;
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

namespace YogaStudio.Application.Features.Mentors.Queries.GetMentorDetails
{
    public class GetMentorDetailsQueryHandler
        : IRequestHandler<GetMentorDetailsQuery, MentorDetailsVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetMentorDetailsQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MentorDetailsVm> Handle(GetMentorDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var mentor = await _context.Mentors
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (mentor == null)
                throw new NotFoundException(nameof(Mentor), request.Id);

            return _mapper.Map<MentorDetailsVm>(mentor);
        }
    }
}
