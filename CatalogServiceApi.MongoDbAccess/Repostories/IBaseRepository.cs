using CatalogServiceApi.Domain.MongoModels;

namespace CatalogServiceApi.MongoDbAccess.Repostories
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T> GetByIdAsync(string id);
        Task<IEnumerable<T>> GetAll();
        Task<T> CreateAsync(T entity);
        Task UpdateAsync(string id, T entity);
        Task RemoveAsync(string id);
    }
}
