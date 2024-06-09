using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Memberships.Queries.ListMemberships
{
    public class ListMembershipsQueryHandler(IMembershipRepository membershipRepository) : IRequestHandler<ListMembershipsQuery, List<Membership>>
    {
        public async Task<List<Membership>> Handle(ListMembershipsQuery request, CancellationToken cancellationToken)
        {
            return await membershipRepository.GetAllAsync();
        }
    }
}
