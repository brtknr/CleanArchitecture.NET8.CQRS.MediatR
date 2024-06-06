using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Common.Interfaces
{
    public interface IRepository<T> where T : class 
    {
        
        Task<T?> GetByIdAsync(int id);
        Task<List<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> predicate);
        Task<bool> AddAsync(T entity);
        bool Remove(T entity);
        bool Update(T entity);
        Task<int> SaveAsync();

    }
}
