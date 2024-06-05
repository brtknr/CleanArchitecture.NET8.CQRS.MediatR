using CleanArchitecture.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common.Persistence
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Workout> Workout { get; set; }
        public DbSet<Exercise> Exercise { get; set; }
        public DbSet<Plan> Plan { get; set; }
        public DbSet<Member> Member { get; set; }
        public DbSet<Membership> Membership { get; set; }
    }
}
