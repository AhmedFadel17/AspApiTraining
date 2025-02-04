using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CatalogServiceApi.Domain.MongoModels
{
    public abstract record BaseEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = ObjectId.GenerateNewId().ToString();
    }
}
