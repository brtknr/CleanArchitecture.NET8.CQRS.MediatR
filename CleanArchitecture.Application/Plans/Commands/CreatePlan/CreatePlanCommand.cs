using CleanArchitecture.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Plans.Commands.CreatePlan
{
    public record CreatePlanCommand(string title,
                                    int totalDays,
                                    double price,
                                    DateTime? StartDate,
                                    DateTime? EndDate,
                                    int? MaximumMemberCount,
                                    bool isPermanent) : IRequest<Plan>;
    
}
