using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.YogaClasses.Commands.CreateYogaClass
{
    public class CreateYogaClassCommandValidator : AbstractValidator<CreateYogaClassCommand>
    {
        public CreateYogaClassCommandValidator()
        {
            RuleFor(command => command.MentorId).NotEqual(Guid.Empty);
        }
    }
}
