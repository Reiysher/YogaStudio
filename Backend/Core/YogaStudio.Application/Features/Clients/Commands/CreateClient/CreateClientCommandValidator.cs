using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YogaStudio.Application.Features.Clients.Commands.CreateClient
{
    public class CreateClientCommandValidator : AbstractValidator<CreateClientCommand>
    {
        public CreateClientCommandValidator()
        {
            RuleFor(command => command.Id).NotEqual(Guid.Empty);
            RuleFor(command => command.FirstName).NotEmpty().MaximumLength(100);
            RuleFor(command => command.LastName).NotEmpty().MaximumLength(100);
        }
    }
}
