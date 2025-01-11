using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Question.Paragraph
{
    public class UpdateParagraphDto
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
