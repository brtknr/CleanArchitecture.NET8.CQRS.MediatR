using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Memberships.Commands.CreateMembership
{
    public sealed class CreateMembershipCommandValidator
    : AbstractValidator<CreateMembershipCommand>
    {
        public CreateMembershipCommandValidator()
        {
            RuleFor(command => command.memberId)
                 .NotNull()
                 .WithMessage("You must choose a member to create a membership.");


            RuleFor(command => command.startDate)
                  .NotNull()
                  .WithMessage("Start date must be selected.");

            RuleFor(command => command.planId)
                  .NotNull()
                  .WithMessage("You must choose a plan to create a membership.");

        }
    }
}
