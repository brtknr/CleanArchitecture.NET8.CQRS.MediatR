using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Infrastructure.Common.Persistence
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        internal ApplicationDbContext _context;
        internal DbSet<TEntity> dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            dbSet = context.Set<TEntity>();
        }

        public async Task<bool> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = await dbSet.AddAsync(entity);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<List<TEntity>> GetAllAsync()
             => await dbSet
                        .AsNoTracking()
                        .ToListAsync();

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            var entity = await dbSet.FindAsync(id);
            return entity;
        }

        public bool Remove(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = dbSet.Remove(entity);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool Update(TEntity entity)
        {
            EntityEntry<TEntity> entityEntry = dbSet.Update(entity);
            return entityEntry.State == EntityState.Modified;
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
            => dbSet.Where(predicate);
        

        public async Task<int> SaveAsync()
           => await _context.SaveChangesAsync();
    }
}
