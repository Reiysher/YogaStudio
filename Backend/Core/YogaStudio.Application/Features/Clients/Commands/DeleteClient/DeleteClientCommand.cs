using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
