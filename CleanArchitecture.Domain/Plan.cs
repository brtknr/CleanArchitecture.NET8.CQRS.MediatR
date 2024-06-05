using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Plan : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public int TotalDays { get; set; }
        public double Price { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? MaximumMemberCount { get; set; }
        public bool IsPermanent { get; set; }
        public ICollection<Membership> Memberships { get; set; } = new List<Membership>();
    }
}
