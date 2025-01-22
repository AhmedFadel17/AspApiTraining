using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.HeadingQuestions
{
    public record UpdateHeadingQuestionDto
    {
        [MaxLength(255)]
        public string? Title { get; set; }
        [Range(0, 1000)]
        public double? TotalMarks { get; set; }
        [Range(0, 1000)]
        public int? DisplayOrder { get; set; }
    }
}
