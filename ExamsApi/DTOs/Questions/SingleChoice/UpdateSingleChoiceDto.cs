using ExamsApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Questions.SingleChoice
{
    public class UpdateSingleChoiceDto : IUpdateQuestionDto
    {
        [Range(0, 1000)]
        public double? Marks { get; set; }
        [Range(0, 1000)]
        public int? DisplayOrder { get; set; }
        [MaxLength(455)]
        public string? QuestionText { get; set; }
        [MaxLength(255)]
        public string? Choice1 { get; set; }
        [MaxLength(255)]
        public string? Choice2 { get; set; }
        [MaxLength(255)]
        public string? Choice3 { get; set; }
        [MaxLength(255)]
        public string? Choice4 { get; set; }
        [MaxLength(255)]
        public string? Answer { get; set; }
    }
}
