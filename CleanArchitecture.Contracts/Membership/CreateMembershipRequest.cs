using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contracts.Membership
{
    public record CreateMembershipRequest(string memberId,string planId,DateTime startDate);
    
}
