using CleanArchitecture.Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain
{
    public class Exercise : BaseEntity
    {
        [ForeignKey("Workout")]
        public int? WorkoutId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Workout? Workout { get; set; }

    }
}
