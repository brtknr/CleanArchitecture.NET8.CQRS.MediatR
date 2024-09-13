using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Members.Commands.AddMember
{
    public sealed class AddMemberCommandValidator
    : AbstractValidator<AddMemberCommand>
    {
        public AddMemberCommandValidator()
        {
            RuleFor(command => command.FirstName)
                .NotEmpty()
                .WithMessage("First name cannot be empty.")
                .MinimumLength(3)
                .WithMessage("First name must be at least 3 characters.");

            RuleFor(command => command.LastName)
                .NotEmpty()
                .WithMessage("Last name cannot be empty.")
                .MinimumLength(3)
                .WithMessage("Last name must be at least 3 characters");

        }
    }
}
