using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Question.Paragraph
{
    public class CreateParagraphDto
    {
        [Required]
        public int MainQuestionId { get; set; }
        [Required, Range(0, 1000)]
        public double Marks { get; set; }
        [Required, Range(0, 1000)]
        public int DisplayOrder { get; set; }
        [Required, Range(0, 5000)]
        public int MinWords { get; set; }
        [Required, MaxLength(255)]
        public required string Title { get; set; }
        [Required, MaxLength(255)]
        public string? GuidingWords { get; set; }
    }
}
