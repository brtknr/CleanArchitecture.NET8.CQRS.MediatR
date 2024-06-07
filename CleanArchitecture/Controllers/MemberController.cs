using CleanArchitecture.Application.Members.Queries.ListMembers;
using CleanArchitecture.Domain;
using CleanArchitecture.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Members.Commands.AddMember;
using System.Net;
using CleanArchitecture.Contracts.Member;

namespace CleanArchitecture.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class MemberController(ISender _mediator) : ControllerBase
    {
    
        [HttpGet]
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var query = new ListMembersQuery();
            return await _mediator.Send(query);
        }

        [HttpPost]
        public async Task<MemberResponse> AddMember(Contracts.AddMemberRequest request)
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
