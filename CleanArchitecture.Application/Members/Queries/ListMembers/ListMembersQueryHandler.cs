using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Services;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
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
            
            if(cacheService.TryGetValue("memberList", out List<Member>? memberList))
            {
                return memberList;
            }
            else
            {
                var members = await _uow.MemberRepository.GetAllAsync();
                
                await cacheService.SetAsync("memberList", members,new DistributedCacheEntryOptions() { SlidingExpiration = TimeSpan.FromMinutes(30) });

                return members;

            }
        }
    }
}
