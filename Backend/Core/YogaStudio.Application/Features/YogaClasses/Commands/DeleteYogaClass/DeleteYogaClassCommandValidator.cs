using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.YogaClasses.Commands.DeleteYogaClass
{
    public class DeleteYogaClassCommandValidator : AbstractValidator<DeleteYogaClassCommand>
    {
        public DeleteYogaClassCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
