using ExamsApi.Domain.Enums;

namespace ExamsApi.Application.DTOs.Questions
{
    public record IQuestionResponseDto
    {
        public int Id { get; set; }
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
        public QuestionType QuestionType { get; set; }
    }
}
