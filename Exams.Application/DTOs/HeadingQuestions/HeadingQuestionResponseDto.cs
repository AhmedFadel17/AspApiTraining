namespace ExamsApi.Application.DTOs.HeadingQuestions
{
    public record HeadingQuestionResponseDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int ExamModelId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
    }
}
