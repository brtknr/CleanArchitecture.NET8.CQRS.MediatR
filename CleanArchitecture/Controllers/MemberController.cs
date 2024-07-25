using CleanArchitecture.Application.Members.Queries.ListMembers;
using CleanArchitecture.Domain;
using CleanArchitecture.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Members.Commands.AddMember;
using System.Net;
using CleanArchitecture.Contracts.Member;
using CleanArchitecture.Application.Common.Filters;
using Microsoft.AspNetCore.Mvc.Filters;
using RabbitMQ.Client;
using CleanArchitecture.Infrastructure.Common.RabbitMQ;

namespace CleanArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MemberController(ISender _mediator,IPublisherService _publisherService) : ControllerBase
    {
    
        [HttpGet]
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var query = new ListMembersQuery();


            #region RabbitMQ Test

            var membershipList = new List<Membership>();
            membershipList.Add(new() { Id = 8, MemberId = 2, PlanId = 7 });

            _publisherService.Enqueue(membershipList, "test_queue", "forecast_exchange", ExchangeType.Direct, "");

            #endregion


            return await _mediator.Send(query);
        }

        [HttpPost]
        [TypeFilter(typeof(InvalidateCacheFilterAsync), Arguments = new object[] { "members" })] // invalidates given key by removing it from cache
        public async Task<MemberResponse> AddMember(AddMemberRequest request)
        {
            var command = new AddMemberCommand(request.FirstName,
                                                request.LastName,
                                                request.Email,
                                                request.PhoneNumber,
                                                request.Address
                                                );

            var result = await _mediator.Send(command);


            return new(result.FirstName, result.LastName, result.Email, result.PhoneNumber, result.Address);
        }

        




    }
}
