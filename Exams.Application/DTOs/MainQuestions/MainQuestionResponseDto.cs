namespace ExamsApi.Application.DTOs.MainQuestions
{
    public class MainQuestionResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int HeadingQuestionId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
        public string Description { get; set; }
    }
}
