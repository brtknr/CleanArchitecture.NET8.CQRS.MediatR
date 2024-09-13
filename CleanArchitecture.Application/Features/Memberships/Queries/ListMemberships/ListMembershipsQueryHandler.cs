using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Memberships.Queries.ListMemberships
{
    public class ListMembershipsQueryHandler(IUnitOfWork _uow) : IRequestHandler<ListMembershipsQuery, List<Membership>>
    {
        public async Task<List<Membership>> Handle(ListMembershipsQuery request, CancellationToken cancellationToken)
        {
            return await _uow.MembershipRepository.GetAllAsync();
        }
    }
}
