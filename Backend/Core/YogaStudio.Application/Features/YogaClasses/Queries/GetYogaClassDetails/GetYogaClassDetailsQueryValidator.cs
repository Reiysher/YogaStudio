using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassDetails
{
    public class GetYogaClassDetailsQueryValidator : AbstractValidator<GetYogaClassDetailsQuery>
    {
        public GetYogaClassDetailsQueryValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
