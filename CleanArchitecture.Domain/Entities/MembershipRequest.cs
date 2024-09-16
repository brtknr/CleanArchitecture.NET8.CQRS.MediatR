using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class MembershipRequest : BaseEntity
    {
        public string RequesterId { get; set; }
        public int GymId { get; set; }
        public int PlanId { get; set; } // after request is accepted by gym . the payment process continues by using this selected planId
        public int Status { get; set; }
        public DateTime? ResponseDate { get; set; }
        public string? ResponseDescription { get; set; }
    }
}
