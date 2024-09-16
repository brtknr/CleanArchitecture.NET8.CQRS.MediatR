using CleanArchitecture.Domain.Common;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }

        public string Name { get; set; }
        public string? Surname { get; set; } // not required for business . just name property is ok
        public int? Gender { get; set; } 
        public string? MersisNo { get; set; } // for businesses
        public string? Address { get; set; }
        public bool isBusiness { get; set; } // 1 for business - 0 for customer

    }
}
