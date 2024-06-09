using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Memberships.Commands.CreateMembership
{
    public record CreateMembershipResponse(string memberFirstName,
                                           string memberLastName,  
                                           string planTitle,
                                           DateTime startDate,
                                           DateTime endDate,
                                           int remainingDaysCount);
    
}
