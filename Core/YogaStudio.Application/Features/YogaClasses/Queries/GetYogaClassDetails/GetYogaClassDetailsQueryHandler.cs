using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using YogaStudio.Application.Common.Exceptions;
using YogaStudio.Application.Interfaces;
using YogaStudio.Domain;

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassDetails
{
    public class GetYogaClassDetailsQueryHandler
        : IRequestHandler<GetYogaClassDetailsQuery, YogaClassDetailsVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetYogaClassDetailsQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<YogaClassDetailsVm> Handle(GetYogaClassDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _context.Classes
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (entity == null)
                throw new NotFoundException(nameof(YogaClass), request.Id);

            return _mapper.Map<YogaClassDetailsVm>(entity);
        }
    }
}
