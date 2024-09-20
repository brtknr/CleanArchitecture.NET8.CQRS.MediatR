﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class GymRepository : Repository<Gym>, IGymRepository
    {
        public GymRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}