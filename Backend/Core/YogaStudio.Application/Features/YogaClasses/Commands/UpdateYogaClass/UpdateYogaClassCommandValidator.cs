using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.YogaClasses.Commands.UpdateYogaClass
{
    public class UpdateYogaClassCommandValidator : AbstractValidator<UpdateYogaClassCommand>
    {
        public UpdateYogaClassCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
