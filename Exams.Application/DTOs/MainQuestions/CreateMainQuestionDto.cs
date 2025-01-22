using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.MainQuestions
{
    public class CreateMainQuestionDto
    {
        [Required, MaxLength(255)]
        public required string Title { get; set; }
        [Required]
        public int HeadingQuestionId { get; set; }
        [Required, Range(0, 1000)]
        public double TotalMarks { get; set; }
        [Required, Range(0, 1000)]
        public int DisplayOrder { get; set; }
        [Required, MaxLength(455)]
        public required string Description { get; set; }
    }
}
