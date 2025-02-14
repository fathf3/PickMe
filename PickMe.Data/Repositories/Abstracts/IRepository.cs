using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PickMe.Data.Repositories.Abstracts
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        
        Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate);
        Task<T> AddAsync(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsync(T entity);
        Task RemoveAsync(T entity);
        Task SaveChangesAsync();
    }
}
