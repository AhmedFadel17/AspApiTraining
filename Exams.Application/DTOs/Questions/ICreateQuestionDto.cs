namespace ExamsApi.Application.DTOs.Questions
{
    public record ICreateQuestionDto
    {
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
    }
}
