﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain
{
    public class Workout : BaseEntity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public virtual ICollection<Exercise> Exercises { get; set; }

    }
}
