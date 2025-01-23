using ExamsApi.Application.DTOs.Questions;
using ExamsApi.Domain.Models;

namespace ExamsApi.Application.DTOs.Exams
{
    public record FullMainQuestionResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int HeadingQuestionId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
    }
}
