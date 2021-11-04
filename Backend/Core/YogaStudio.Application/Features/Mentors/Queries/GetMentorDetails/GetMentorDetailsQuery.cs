using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Mentors.Queries.GetMentorDetails
{
    public class GetMentorDetailsQuery : IRequest<MentorDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
