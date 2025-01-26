using System.Text.Json.Serialization;

namespace CatalogServiceApi.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }
    }
}
