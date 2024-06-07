using CleanArchitecture.Application.Members.Queries.ListMembers;
using CleanArchitecture.Domain;
using CleanArchitecture.Contracts;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CleanArchitecture.Application.Members.Commands.AddMember;
using System.Net;

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

        //[HttpGet]
        //public Member GetMemberById(int id)
        //{
        //    var member = MemberList.FirstOrDefault(x => x.Id == id);
        //    if (member == null) throw new Exception("Cannot find the member linked the specified id");
        //    return member;
        //}

        [HttpPost]
        public async Task<Member> AddMember(AddMemberRequest request)
        {
            var command = new AddMemberCommand(request.FirstName,
                                                request.LastName,
                                                request.Email,
                                                request.PhoneNumber,
                                                request.Address
                                                );

            var result = await _mediator.Send(command);
            return result;
        }


    }
}
