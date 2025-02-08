
using System.Diagnostics.CodeAnalysis;

namespace CatalogServiceApi.Application.DTOs.Products
{
    [ExcludeFromCodeCoverage]
    public record ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
