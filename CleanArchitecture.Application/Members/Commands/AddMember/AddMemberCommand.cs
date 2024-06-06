using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Members.Commands.AddMember
{
    public record AddMemberCommand(string? FirstName,
                                      string? LastName,
                                      string? Email,
                                      string? PhoneNumber,
                                      string? Address) : IRequest<Member>;
   
}
