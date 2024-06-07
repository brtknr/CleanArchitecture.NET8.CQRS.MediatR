using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Contracts.Member
{
    public record MemberResponse(string? FirstName,
                                  string? LastName,
                                  string? Email,
                                  string? PhoneNumber,
                                  string? Address);
}
