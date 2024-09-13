using CleanArchitecture.Application.Common.Behaviors;
using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Errors;
using CleanArchitecture.Domain;
using FluentValidation.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Memberships.Commands.CreateMembership
{
    public class CreateMembershipCommandHandler(IUnitOfWork _uow) : IRequestHandler<CreateMembershipCommand, CreateMembershipResponse>
    {
        public async Task<CreateMembershipResponse> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {

            var member = _uow.MemberRepository.GetByIdAsync(request.memberId).Result;
            var plan = _uow.PlanRepository.GetByIdAsync(request.planId).Result;

            if (member == null || plan == null)
            {
                var errorList = new List<ValidationError>();
                errorList.Add(new ValidationError("Plan,Member", "Plan or member is not found."));
                throw new Exceptions.ValidationException(errorList);
            }

            Membership membership = new()
            {
                MemberId = request.memberId,
                PlanId = request.planId,
                StartDate = request.startDate,
                EndDate = request.startDate.AddDays(plan.TotalDays)
            };

            await _uow.MembershipRepository.AddAsync(membership);
            await _uow.MembershipRepository.SaveAsync();



            return new(member.FirstName,
                       member.LastName,
                       plan.Title,
                       request.startDate,
                       request.startDate.AddDays(plan.TotalDays),
                       plan.TotalDays);
        }
    }
}
