using ExamsApi.Domain.Enums;
using ExamsApi.Application.DTOs;

namespace ExamsApi.Application.DTOs.Questions.Paragraph
{
    public record ParagraphResponseDto
    {
        public int Id { get; set; }
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
        public QuestionType QuestionType { get; set; } = QuestionType.Paragraph;
        public int MinWords { get; set; }
        public string Title { get; set; }
        public string GuidingWords { get; set; }
    }
}
