using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Services;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Members.Queries.ListMembers
{
    public class ListMembersQueryHandler(IUnitOfWork _uow,ICacheService cacheService) : IRequestHandler<ListMembersQuery, List<Member>>
    {

        public async Task<List<Member>> Handle(ListMembersQuery request, CancellationToken cancellationToken)
        {
            
            if(cacheService.TryGetValue("surname", out string? surnameValue))
            {
                // return data from cache
            }
            else
            {
                // fetch data from db . store it to cache and return to presentation.
            }

            
            return await _uow.MemberRepository.GetAllAsync();
        }
    }
}
