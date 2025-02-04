using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System.Text.Json.Serialization;

namespace CatalogServiceApi.Domain.MongoModels
{
    public record Product : BaseEntity
    {

        [BsonElement("name")] 
        public required string Name { get; set; }

        [BsonElement("description")]
        public required string Description { get; set; }

        [BsonElement("price")]
        public required List<Price> Prices { get; set; }

        [BsonElement("categoryId")] 
        public required string CategoryId { get; set; } 

        [JsonIgnore]  
        [BsonIgnore]  
        public Category? Category { get; set; }
    }

    public record Price
    {
        public decimal From { get; set; }

        public decimal To { get; set; }

    }
}
