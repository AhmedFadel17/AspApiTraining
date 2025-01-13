using ExamsApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Questions
{
    public interface IUpdateQuestionDto
    {
        [Range(0, 1000)]
        public double? Marks { get; set; }
        [Range(0, 1000)]
        public int? DisplayOrder { get; set; }
    }
}
