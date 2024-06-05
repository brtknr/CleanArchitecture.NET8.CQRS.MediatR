using CleanArchitecture.Application.Common.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public Task AddAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public TEntity Update(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}
