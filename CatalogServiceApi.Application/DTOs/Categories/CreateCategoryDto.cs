using System.ComponentModel.DataAnnotations;

namespace CatalogServiceApi.Application.DTOs.Categories
{
    public record CreateCategoryDto
    {
        [Required(ErrorMessage = "Name is required")]
        [StringLength(255, ErrorMessage = "Name cannot exceed 255 characters")]
        public required int Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [StringLength(255, ErrorMessage = "Description cannot exceed 255 characters")]
        public required string Description { get; set; }
    }
}
