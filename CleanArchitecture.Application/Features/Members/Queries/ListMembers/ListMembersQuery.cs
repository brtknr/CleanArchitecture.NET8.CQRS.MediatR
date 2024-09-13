using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Members.Queries.ListMembers
{
    public record ListMembersQuery() : IRequest<List<Member>>;

}
