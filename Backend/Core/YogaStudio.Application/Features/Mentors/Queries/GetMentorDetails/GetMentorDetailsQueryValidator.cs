using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Mentors.Queries.GetMentorDetails
{
    public class GetMentorDetailsQueryValidator : AbstractValidator<GetMentorDetailsQuery>
    {
        public GetMentorDetailsQueryValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
