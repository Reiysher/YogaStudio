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

namespace YogaStudio.Application.Features.Clients.Queries.GetClientsList
{
    public class GetClientsListQueryHandler
        : IRequestHandler<GetClientsListQuery, ClientsListVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetClientsListQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ClientsListVm> Handle(GetClientsListQuery request, 
            CancellationToken cancellationToken)
        {
            var clients = await _context.Clients
                .ProjectTo<ClientLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ClientsListVm { Clients = clients };
        }
    }
}
