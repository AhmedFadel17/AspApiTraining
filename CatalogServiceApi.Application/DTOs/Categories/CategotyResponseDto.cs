
namespace CatalogServiceApi.Application.DTOs.Categories
{
    public record CategotyResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
