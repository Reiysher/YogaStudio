using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Clients.Commands.DeleteClient
{
    public class DeleteClientCommandValidator : AbstractValidator<DeleteClientCommand>
    {
        public DeleteClientCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
        }
    }
}
