﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Clients.Queries.GetClientsList
{
    public class GetClientListQuery : IRequest<ClientListVm>
    {
    }
}
