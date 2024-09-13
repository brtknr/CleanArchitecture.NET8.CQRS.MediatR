using CleanArchitecture.Application.Common.Filters;
using CleanArchitecture.Application.Features.Memberships.Commands.CreateMembership;
using CleanArchitecture.Application.Features.Memberships.Queries.ListMemberships;
using CleanArchitecture.Contracts.Membership;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Common.RabbitMQ;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RabbitMQ.Client;

namespace CleanArchitecture.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MembershipController(ISender _mediator /*,IPublisherService _publisherService*/) : ControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<Membership>> GetAllMemberships()
        {
            var query = new ListMembershipsQuery();

            return await _mediator.Send(query);
        }

        [HttpPost]
        //[TypeFilter(typeof(InvalidateCacheFilterAsync), Arguments = new object[] { "memberships" })]
        public async Task<MembershipResponse> CreateMembership(CreateMembershipRequest request)
        {

            CreateMembershipCommand command = new(Convert.ToInt32(request.memberId),
                                            Convert.ToInt32(request.planId),
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
