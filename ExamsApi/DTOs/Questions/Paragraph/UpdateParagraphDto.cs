using ExamsApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Questions.Paragraph
{
    public class UpdateParagraphDto : IUpdateQuestionDto
    {
        [Range(0, 1000)]
        public double? Marks { get; set; }
        [Range(0, 1000)]
        public int? DisplayOrder { get; set; }
        [Range(0, 5000)]
        public int? MinWords { get; set; }
        [MaxLength(255)]
        public string? Title { get; set; }
        [MaxLength(255)]
        public string? GuidingWords { get; set; }
    }
}
