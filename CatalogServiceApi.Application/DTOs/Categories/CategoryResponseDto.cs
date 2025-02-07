
namespace CatalogServiceApi.Application.DTOs.Categories
{
    public record CategoryResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
