using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQuery : IRequest<ClientDetailsVm>
    {
        public Guid id { get; set; }
    }
}
