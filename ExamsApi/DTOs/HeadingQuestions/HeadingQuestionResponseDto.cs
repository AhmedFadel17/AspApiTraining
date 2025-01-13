using System.Text.Json.Serialization;

namespace ExamsApi.DTOs.HeadingQuestions
{
    public class HeadingQuestionResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExamModelId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
    }
}
