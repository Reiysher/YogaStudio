using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Interfaces;

namespace YogaStudio.Application.Features.Mentors.Queries.GetMentorsList
{
    public class GetMentorsListQueryHandler
        : IRequestHandler<GetMentorsListQuery, MentorsListVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetMentorsListQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MentorsListVm> Handle(GetMentorsListQuery request, 
            CancellationToken cancellationToken)
        {
            var mentors = await _context.Mentors
                .ProjectTo<MentorLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new MentorsListVm { Mentors = mentors };
        }
    }
}
