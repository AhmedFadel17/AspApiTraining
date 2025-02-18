﻿using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CatalogServiceApi.DataAccess.Repostories
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void BulkRemove(IEnumerable<T> entityList);
        void BulkUpdate(IEnumerable<T> entityList);

        Task<int> BulkDeleteAsync(Expression<Func<T, bool>> predicate);
        Task<int> BulkUpdateAsync(Expression<Func<T, bool>> predicate, Expression<Func<SetPropertyCalls<T>, SetPropertyCalls<T>>> updateExpression);
        Task SaveChangesAsync();
    }
}
