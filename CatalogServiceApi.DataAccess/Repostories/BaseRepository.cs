using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Diagnostics.CodeAnalysis;
using CatalogServiceApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Microsoft.EntityFrameworkCore.Query;

namespace CatalogServiceApi.DataAccess.Repostories
{
    [ExcludeFromCodeCoverage]
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        public readonly DbSet<T> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void BulkRemove(IEnumerable<T> entityList)
        {
            _dbSet.RemoveRange(entityList);

        }
        public async Task<int> BulkDeleteAsync(Expression<Func<T, bool>> predicate)
        {
            return await _dbSet.Where(predicate).ExecuteDeleteAsync();
        }
        public async Task<int> BulkUpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression)
        {
            return await _dbSet.Where(predicate).ExecuteUpdateAsync(updateExpression);
        }


        public void BulkUpdate(IEnumerable<T> entityList)
        {
            _dbSet.UpdateRange(entityList);
        }

    }
}
