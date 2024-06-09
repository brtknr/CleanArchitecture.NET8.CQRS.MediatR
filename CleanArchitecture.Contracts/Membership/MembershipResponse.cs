using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contracts.Membership
{
    public record MembershipResponse(string MemberFullName,string planTitle,DateTime startDate,DateTime endDate,int remainingDaysCount);
    
}
