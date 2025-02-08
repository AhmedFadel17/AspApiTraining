using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatalogServiceApi.Application.DTOs.Products
{
    [ExcludeFromCodeCoverage]
    public record UpdateProductDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public required string Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public required decimal Price { get; set; }

        [Required(ErrorMessage = "Category Id is required")]
        public required int CategoryId { get; set; }
    }
}
