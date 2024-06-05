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
        internal new DbSet<Member> dbSet;

        public MemberRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Member>> GetMemberActiveDays(Member member)
        {
            throw new NotImplementedException();
        }
    }
}
