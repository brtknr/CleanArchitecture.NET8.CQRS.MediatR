using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Memberships.Queries.ListMemberships
{
    public record ListMembershipsQuery() : IRequest<List<Membership>>;

}
