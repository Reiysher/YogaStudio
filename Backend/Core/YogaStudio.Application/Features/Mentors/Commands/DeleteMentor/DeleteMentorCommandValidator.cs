using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Mentors.Commands.DeleteMentor
{
    public class DeleteMentorCommandValidator : AbstractValidator<DeleteMentorCommand>
    {
        public DeleteMentorCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
