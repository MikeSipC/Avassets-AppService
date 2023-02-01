using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ExampleService.SharedKernel;
using ExampleService.SharedKernel.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace ExampleService.Infrastructure.Data
{
    /// <summary>
    /// EF implementation example
    /// </summary>
    public class EfRepository : IRepository
    {
        private readonly AppDbContext _dbContext;

        public EfRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<T> GetByIdAsync<T, TId>(TId id) where T : BaseEntity<TId>
        {
            return _dbContext.Set<T>().SingleOrDefaultAsync(e => e.Id.Equals(id));
        }

        public Task<List<T>> ListAsync<T, TId>() where T : BaseEntity<TId>
        {
            return _dbContext.Set<T>().ToListAsync();
        }

        public Task<List<T>> FindAsync<T, TId>(Expression<Func<T, bool>> predicate) where T : BaseEntity<TId>
        {
            return _dbContext.Set<T>().AsQueryable().Where(predicate).ToListAsync();
        }

        public async Task<T> AddAsync<T, TId>(T entity) where T : BaseEntity<TId>
        {
            await _dbContext.Set<T>().AddAsync(entity);
            return entity;
        }

        public async Task UpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public async Task<T> AddOrUpdateAsync<T, TId>(T entity) where T : BaseEntity<TId>
        {
            if (_dbContext.Set<T>().Any(x => x.Id.Equals(entity.Id)))
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
            }
            else
            {
                await _dbContext.Set<T>().AddAsync(entity);
            }
            return entity;
        }


        public async Task DeleteAsync<T, TId>(T entity) where T : BaseEntity<TId>
        {
            _dbContext.Set<T>().Remove(entity);
        }

        public async Task DeleteRangeAsync<T, TId>(IEnumerable<T> list) where T : BaseEntity<TId>
        {
            _dbContext.Set<T>().RemoveRange(list);
        }

        public IQueryable<T> Query<T, TId>() where T : BaseEntity<TId>
        {
            return _dbContext.Set<T>().AsQueryable();
        }

        public T GetById<T, TId>(TId id) where T : BaseEntity<TId>
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id.Equals(id));
        }

        public IQueryable<T> SqlQuery<T, TId>(string sql, params object[] parameters) where T : BaseEntity<TId>
        {
            return _dbContext.Set<T>().FromSqlRaw(sql, parameters);
        }
    }
}