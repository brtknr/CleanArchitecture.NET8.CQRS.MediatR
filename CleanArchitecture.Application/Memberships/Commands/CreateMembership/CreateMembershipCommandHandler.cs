using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Memberships.Commands.CreateMembership
{
    public class CreateMembershipCommandHandler(IMembershipRepository membershipRepository,
                                                IMemberRepository memberRepository,
                                                IPlanRepository planRepository) : IRequestHandler<CreateMembershipCommand, CreateMembershipResponse>
    {                                                                                  
        public async Task<CreateMembershipResponse> Handle(CreateMembershipCommand request, CancellationToken cancellationToken)
        {

            var member = memberRepository.GetByIdAsync(request.memberId).Result;
            var plan = planRepository.GetByIdAsync(request.planId).Result;

            if (member == null || plan == null) throw new Exception("Member or plan is not found."); // TO DO : fix 

            Membership membership = new()
                                    {
                                        MemberId = request.memberId,
                                        PlanId = request.planId,
                                        StartDate = request.startDate,
                                        EndDate = request.startDate.AddDays(plan.TotalDays)
                                    };


            await membershipRepository.AddAsync(membership);
            await memberRepository.SaveAsync();

            return new(member.FirstName,
                       member.LastName,
                       plan.Title,
                       request.startDate,
                       request.startDate.AddDays(plan.TotalDays),
                       plan.TotalDays);
        }
    }
}
