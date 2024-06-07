using CleanArchitecture.Application.Members.Queries.ListMembers;
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

        //[HttpPost]
        //public async Task<PlanResponse> Create(CreatePlanRequest request)
        //{
        //    await return new PlanResponse();
        //}


    }
}
