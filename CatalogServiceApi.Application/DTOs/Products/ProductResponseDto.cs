
using CatalogServiceApi.Domain.MongoModels;

namespace CatalogServiceApi.Application.DTOs.Products
{
    public record ProductResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Price> Prices { get; set; }
        public string CategoryId { get; set; }
    }
}
