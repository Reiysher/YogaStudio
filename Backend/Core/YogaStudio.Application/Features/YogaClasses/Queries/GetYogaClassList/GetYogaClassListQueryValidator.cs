using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassList
{
    public class GetYogaClassListQueryValidator : AbstractValidator<GetYogaClassListQuery>
    {
        public GetYogaClassListQueryValidator()
        {
            // empty
        }
    }
}
