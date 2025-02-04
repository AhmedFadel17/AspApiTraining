using CatalogServiceApi.Domain.MongoModels;
using MongoDB.Driver;

namespace CatalogServiceApi.MongoDbAccess.Repostories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly IMongoCollection<T> _collection;

        public BaseRepository(IMongoDatabase database,string collectionName)
        {
            _collection = database.GetCollection<T>(collectionName);
        }
        public async Task<T> CreateAsync(T entity)
        {
            await _collection.InsertOneAsync(entity);
            return entity;
        }

        public async Task<T> GetByIdAsync(string id)
        {
            return await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();

        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task UpdateAsync(string id,T entity)
        {
            await _collection.ReplaceOneAsync(x => x.Id == id, entity);

        }

        public async Task RemoveAsync(string id)
        {
            await _collection.DeleteOneAsync(x => x.Id == id);
        }
    }
}
