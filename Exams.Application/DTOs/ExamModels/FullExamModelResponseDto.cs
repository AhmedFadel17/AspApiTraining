using ExamsApi.Domain.Models;

namespace ExamsApi.Application.DTOs.Exams
{
    public record FullExamModelResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExamId { get; set; }
        public List<FullHeadingQuestionResponseDto> HeadingQuestions { get; set; }
    }
}
