﻿using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Common.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class MembershipRepository : Repository<Membership>, IMembershipRepository
    {
        public MembershipRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
