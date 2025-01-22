using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.MainQuestions
{
    public record UpdateMainQuestionDto
    {
        [MaxLength(255)]
        public string? Title { get; set; }
        [Range(0, 1000)]
        public double? TotalMarks { get; set; }
        [Range(0, 1000)]
        public int? DisplayOrder { get; set; }
        [MaxLength(455)]
        public string? Description { get; set; }
    }
}
