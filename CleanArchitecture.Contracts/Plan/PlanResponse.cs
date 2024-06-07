using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contracts.Plan
{
    public record PlanResponse(string title,
                               double price,
                               bool isPermanent,
                               int? maxMemberCount,
                               DateTime? startDate,
                               DateTime? endDate,
                               int totalDays);
    
}
