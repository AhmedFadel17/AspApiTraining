
namespace ExamsApi.Application.DTOs.Questions
{
    public interface IUpdateQuestionDto
    {
        public double? Marks { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
