namespace CatalogServiceApi.DataAccess.Repostories
{
    public interface IBaseRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        void BulkRemove(IEnumerable<T> entityList);
        void BulkUpdate(IEnumerable<T> entityList);
        Task SaveChangesAsync();
    }
}
