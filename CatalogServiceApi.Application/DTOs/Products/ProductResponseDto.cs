
namespace CatalogServiceApi.Application.DTOs.Products
{
    public record ProducResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
