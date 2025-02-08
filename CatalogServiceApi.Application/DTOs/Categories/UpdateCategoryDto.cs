using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace CatalogServiceApi.Application.DTOs.Categories
{
    [ExcludeFromCodeCoverage]
    public record UpdateCategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public required string Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public required string Description { get; set; }
    }
}
