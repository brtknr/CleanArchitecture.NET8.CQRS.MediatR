using CleanArchitecture.Application.Common.Filters;
using CleanArchitecture.Application.Members.Queries.ListMembers;
using CleanArchitecture.Application.Plans.Commands.CreatePlan;
using CleanArchitecture.Application.Plans.Queries.ListPlans;
using CleanArchitecture.Contracts.Plan;
using CleanArchitecture.Domain;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitecture.Api.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PlanController(ISender _mediator) : ControllerBase
    {

        [HttpGet]
        public async Task<IEnumerable<Plan>> GetAllPlans()
        {
            var query = new ListPlansQuery();
            return await _mediator.Send(query);
        }

        [HttpPost]
        //[TypeFilter(typeof(InvalidateCacheFilterAsync), Arguments = new object[] { "plans" })]
        public async Task<PlanResponse> CreatePlan(CreatePlanRequest request)
        {

            CreatePlanCommand command = new(request.title,
                                            request.totalDays,
                                            request.price,
                                            request.startDate,
                                            request.endDate,
                                            request.maxMemberCount,
                                            request.isPermanent); 

            var result = await _mediator.Send(command);

            return new(request.title,
                               request.price,
                               request.isPermanent,
                               request.maxMemberCount,
                               request.startDate,
                               request.endDate,
                               request.totalDays);
        }


    }
}
