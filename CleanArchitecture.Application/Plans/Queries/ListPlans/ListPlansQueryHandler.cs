using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Plans.Queries.ListPlans
{
    public class ListPlansQueryHandler(IPlanRepository _planRepository) : IRequestHandler<ListPlansQuery, List<Plan>>
    {
        public async Task<List<Plan>> Handle(ListPlansQuery request, CancellationToken cancellationToken)
        {
            return await _planRepository.GetAllAsync();
        }
    }
}
