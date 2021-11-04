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

namespace YogaStudio.Application.Features.Subscriptions.Queries.GetSubscriptionDetails
{
    public class GetSubscriptionDetailsQueryHandler
        : IRequestHandler<GetSubscriptionDetailsQuery, SubscriptionDetailsVm>
    {
        private readonly IYogaStudioDbContext _context;
        private readonly IMapper _mapper;

        public GetSubscriptionDetailsQueryHandler(IYogaStudioDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async  Task<SubscriptionDetailsVm> Handle(GetSubscriptionDetailsQuery request, 
            CancellationToken cancellationToken)
        {
            var subscription = await _context.Subscriptions
                .FirstOrDefaultAsync(c => c.Id == request.Id, cancellationToken);

            if (subscription == null)
                throw new NotFoundException(nameof(Subscription), request.Id);

            return _mapper.Map<SubscriptionDetailsVm>(subscription);
        }
    }
}
