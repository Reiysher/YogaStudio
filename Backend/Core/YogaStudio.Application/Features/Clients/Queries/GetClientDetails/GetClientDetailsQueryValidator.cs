using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Clients.Queries.GetClientDetails
{
    public class GetClientDetailsQueryValidator : AbstractValidator<GetClientDetailsQuery>
    {
        public GetClientDetailsQueryValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
