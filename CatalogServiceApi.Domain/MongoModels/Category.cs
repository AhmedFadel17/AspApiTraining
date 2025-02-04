using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CatalogServiceApi.Domain.MongoModels
{
    public record Category : BaseEntity
    {

        [BsonElement("name")] // Explicit mapping to MongoDB field
        public required string Name { get; set; }

        [BsonElement("description")]
        public string? Description { get; set; }

        [JsonIgnore] // Exclude from JSON serialization (but still stored in MongoDB)
        [BsonIgnore] // Prevent MongoDB from trying to serialize this
        public ICollection<Product>? Products { get; set; }
    }
}
