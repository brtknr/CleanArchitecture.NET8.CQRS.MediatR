using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Membership : BaseEntity
    {
        [ForeignKey("Member")]
        public int? MemberId { get; set; }
        [ForeignKey("Plan")]
        public int? PlanId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsActive { get; set; } = true;
        public Plan? Plan { get; set; }
        public Member? Member { get; set; } 
    }
}
