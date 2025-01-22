using ExamsApi.Domain.Enums;
using ExamsApi.Application.DTOs;
namespace ExamsApi.Application.DTOs.Questions.SingleChoice
{
    public class SingleChoiceResponseDto : IQuestionResponseDto
    {
        public int Id { get; set; }
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
        public QuestionType QuestionType { get; set; } = QuestionType.SingleChoice;
        public string QuestionText { get; set; }
        public string Choice1 { get; set; }
        public string Choice2 { get; set; }
        public string Choice3 { get; set; }
        public string Choice4 { get; set; }
        public string Answer { get; set; }
    }
}
