namespace CatalogServiceApi.DataAccess.Repostories
{
    public interface IBaseRepository <T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> CreateAsync(T entity);
        void Update(T entity);
        void Remove(T entity);
        Task SaveChangesAsync();
    }
}
