using CatalogServiceApi.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace CatalogServiceApi.DataAccess.Repostories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {

        protected readonly IMongoCollection<T> _collection;
        public BaseRepository(IMongoDatabase database, string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);

        }
        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public IQueryable<T> GetAll()
        {
            return _collection.AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _collection.Find(Builders<T>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
        }

        public void Remove(T entity)
        {
            //_collection.DeleteOneAsync(x => x.Id == entity.Id);
        }

        public void Update(T entity)
        {
            //_collection.ReplaceOneAsync(Builders<T>.Filter.Eq(e => e.Id, entity.Id), entity);

        }

        public async Task SaveChangesAsync()
        {
            
        }

        
    }
    
}
