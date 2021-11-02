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

namespace YogaStudio.Application.Features.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryHandler
        : IRequestHandler<GetClientDetailsQuery, ClientDetailsVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetClientDetailsQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ClientDetailsVm> Handle(GetClientDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var client = await _context.Clients
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (client == null)
                throw new NotFoundException(nameof(Client), request.Id);

            return _mapper.Map<ClientDetailsVm>(client);
        }
    }
}
