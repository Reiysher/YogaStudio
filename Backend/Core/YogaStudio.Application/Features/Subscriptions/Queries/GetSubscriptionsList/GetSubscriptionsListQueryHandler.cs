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

namespace YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionsList
{
    public class GetSubscriptionsListQueryHandler
        : IRequestHandler<GetSubscriptionsListQuery, SubscriptionsListVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionsListQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<SubscriptionsListVm> Handle(GetSubscriptionsListQuery request, 
            CancellationToken cancellationToken)
        {
            var subscriptions = await _context.Subscriptions
                .ProjectTo<SubscriptionLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new SubscriptionsListVm { Subscriptions = subscriptions };
        }
    }
}
