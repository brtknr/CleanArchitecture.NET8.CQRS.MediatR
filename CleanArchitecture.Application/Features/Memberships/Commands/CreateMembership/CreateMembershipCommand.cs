using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Memberships.Commands.CreateMembership
{
    public record CreateMembershipCommand(int memberId, int planId, DateTime startDate) : IRequest<CreateMembershipResponse>;

}
