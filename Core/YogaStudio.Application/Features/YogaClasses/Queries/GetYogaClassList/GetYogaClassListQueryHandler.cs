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

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList
{
    public class GetYogaClassListQueryHandler
        : IRequestHandler<GetYogaClassListQuery, YogaClassListVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetYogaClassListQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<YogaClassListVm> Handle(GetYogaClassListQuery request, 
            CancellationToken cancellationToken)
        {
            var yogaClasses = await _context.Classes
                .ProjectTo<YogaClassLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync();

            return new YogaClassListVm { Classes = yogaClasses };
        }
    }
}
