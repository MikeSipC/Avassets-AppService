using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ExampleService.SharedKernel.Interfaces
{
    public interface IRepository
    {
        Task<T> GetByIdAsync<T, TId>(TId id) where T : BaseEntity<TId>;
        Task<List<T>> ListAsync<T, TId>() where T : BaseEntity<TId>;
        Task<List<T>> FindAsync<T, TId>(Expression<Func<T, bool>> predicate) where T : BaseEntity<TId>;
        Task<T> AddAsync<T, TId>(T entity) where T : BaseEntity<TId>;
        Task UpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>;
        Task<T> AddOrUpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>;
        Task DeleteAsync<T, TId>(T entity) where T : BaseEntity<TId>;
        Task DeleteRangeAsync<T, TId>(IEnumerable<T> list) where T : BaseEntity<TId>;
        IQueryable<T> Query<T, TId>() where T : BaseEntity<TId>;
        IQueryable<T> SqlQuery<T, TId>(string sql, params object[] parameters) where T : BaseEntity<TId>;
    }
}