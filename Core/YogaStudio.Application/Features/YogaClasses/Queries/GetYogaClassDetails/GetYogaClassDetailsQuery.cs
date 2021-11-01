using MediatR;
using System;

namespace YogaStudio.Application.Features.YogaClasses.Queries.GetYogaClassDetails
{
    public class GetYogaClassDetailsQuery : IRequest<YogaClassDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
