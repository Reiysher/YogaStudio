using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Mentors.Commands.DeleteMentor
{
    public class DeleteMentorCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
