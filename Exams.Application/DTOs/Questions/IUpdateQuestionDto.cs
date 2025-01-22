
namespace ExamsApi.Application.DTOs.Questions
{
    public record IUpdateQuestionDto
    {
        public double? Marks { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
