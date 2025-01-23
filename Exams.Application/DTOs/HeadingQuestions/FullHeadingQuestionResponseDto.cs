using ExamsApi.Domain.Models;

namespace ExamsApi.Application.DTOs.Exams
{
    public record FullHeadingQuestionResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExamModelId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
        public List<FullMainQuestionResponseDto> MainQuestions { get; set; }
    }
}
