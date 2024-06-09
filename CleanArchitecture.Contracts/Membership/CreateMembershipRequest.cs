using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contracts.Membership
{
    public record CreateMembershipRequest(int memberId,int planId,DateTime startDate);
    
}
