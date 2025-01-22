using ExamsApi.Domain.Enums;
using ExamsApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.Questions.Paragraph
{
    public record UpdateParagraphDto : IUpdateQuestionDto
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
