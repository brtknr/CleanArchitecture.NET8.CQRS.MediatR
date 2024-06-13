using CleanArchitecture.Application.Common.Interfaces;
using CleanArchitecture.Domain;
using CleanArchitecture.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Persistence
{
    public class MemberRepository : Repository<Member>, IMemberRepository 
    {
        internal new ApplicationDbContext _context;

        public MemberRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
