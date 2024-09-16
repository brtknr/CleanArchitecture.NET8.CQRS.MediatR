using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities;
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
        public DbSet<Membership> Membership { get; set; }
        public DbSet<Gym> Gym { get; set; }
        public DbSet<ImageFile> ImageFile { get; set; }
        public DbSet<MembershipRequest> MembershipRequest { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var datas = ChangeTracker.Entries<BaseEntity>();

            foreach (var data in datas)
            {
                _ = data.State switch
                {
                    EntityState.Added => data.Entity.CreatedDate = DateTime.UtcNow,
                    EntityState.Modified => data.Entity.UpdatedDate = DateTime.UtcNow,
                };
            }
            
            return await base.SaveChangesAsync(cancellationToken);
        }

    }
}
