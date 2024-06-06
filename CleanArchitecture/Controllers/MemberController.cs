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
        private readonly List<Member> MemberList = new List<Member>() 
        {
            new Member()
            {
                Id = 1,
                FirstName = "Test",
                LastName = "Test",
                PhoneNumber = "050500350323",
                CreatedDate = DateTime.Now,
            },
            new Member()
            {
                Id = 2,
                FirstName = "Test2",
                LastName = "Test2",
                PhoneNumber = "023500350323",
                CreatedDate = DateTime.Now,

            },
            new Member()
            {
                Id = 3,
                FirstName = "Test3",
                LastName = "Test3",
                PhoneNumber = "050545350323",
                CreatedDate = DateTime.Now,
            },
            new Member()
            {
                Id = 4,
                FirstName = "Test4",
                LastName = "Test4",
                PhoneNumber = "011500350323",
                CreatedDate = DateTime.Now
            }
        }; 

    
        [HttpGet]
        public async Task<IEnumerable<Member>> GetAllMembers()
        {
            var query = new ListMembersQuery();
            return await _mediator.Send(query);
        }

        [HttpGet]
        public Member GetMemberById(int id)
        {
            var member = MemberList.FirstOrDefault(x => x.Id == id);
            if (member == null) throw new Exception("Cannot find the member linked the specified id");
            return member;
        }

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
