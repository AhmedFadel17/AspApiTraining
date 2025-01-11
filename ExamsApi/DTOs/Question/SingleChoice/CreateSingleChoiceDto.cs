using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Question.SingleChoice
{
    public class CreateSingleChoiceDto
    {
        [Required]
        public int MainQuestionId { get; set; }
        [Required, Range(0, 1000)]
        public double Marks { get; set; }
        [Required, Range(0, 1000)]
        public int DisplayOrder { get; set; }
        [Required, MaxLength(455)]
        public required string QuestionText { get; set; }
        [Required, MaxLength(99)]
        public required string Choice1 { get; set; }
        [Required, MaxLength(99)]
        public required string Choice2 { get; set; }
        [Required, MaxLength(99)]
        public required string Choice3 { get; set; }
        [Required, MaxLength(99)]
        public required string Choice4 { get; set; }
        [Required, MaxLength(99)]
        public required string Answer { get; set; }
    }
}
