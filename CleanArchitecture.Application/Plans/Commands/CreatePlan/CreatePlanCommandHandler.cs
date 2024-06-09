using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Plans.Commands.CreatePlan
{
    public class CreatePlanCommandHandler(IPlanRepository _planRepository) : IRequestHandler<CreatePlanCommand, Plan>
    {
        public async Task<Plan> Handle(CreatePlanCommand request, CancellationToken cancellationToken)
        {
            var plan = new Plan()
            {
                Title = request.title,
                IsPermanent = request.isPermanent,
                MaximumMemberCount = request.MaximumMemberCount,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TotalDays = request.totalDays,
                Price = request.price,
            };

            var result = await _planRepository.AddAsync(plan);
            await _planRepository.SaveAsync();
            if (result) return plan;

            throw new Exception("Something went wrong!");
        }
    }
}
