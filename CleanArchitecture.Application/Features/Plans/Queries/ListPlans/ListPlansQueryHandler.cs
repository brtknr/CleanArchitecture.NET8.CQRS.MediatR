using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Application.Common.Services;
using CleanArchitecture.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Features.Plans.Queries.ListPlans
{
    public class ListPlansQueryHandler(IUnitOfWork _uow, ICacheService cacheService) : IRequestHandler<ListPlansQuery, List<Plan>>
    {
        public async Task<List<Plan>> Handle(ListPlansQuery request, CancellationToken cancellationToken)
        {
            //string key = "plans";

            //List<Plan>? plans = await cacheService.GetOrCreateAsync(key, async token =>
            //{
            //    var planList = await _uow.PlanRepository.GetAllAsync();

            //    return planList;
            //});

            List<Plan> plans = await _uow.PlanRepository.GetAllAsync();

            return plans ?? new();
        }
    }
}
