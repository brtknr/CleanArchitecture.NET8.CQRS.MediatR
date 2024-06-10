using CleanArchitecture.Application.Memberships.Commands.CreateMembership;
using CleanArchitecture.Application.Memberships.Queries.ListMemberships;
using CleanArchitecture.Contracts.Membership;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MembershipController(ISender _mediator) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Membership>> GetAllMemberships()
        {
            var query = new ListMembershipsQuery();
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<MembershipResponse> CreateMembership(CreateMembershipRequest request)
        {

            CreateMembershipCommand command = new(request.memberId,
                                            request.planId,
                                            request.startDate);

            var result = await _mediator.Send(command);

            return new(result.memberFirstName + " " + result.memberLastName,
                               result.planTitle,
                               result.startDate,
                               result.endDate,
                               result.remainingDaysCount);
        }



    }
}
