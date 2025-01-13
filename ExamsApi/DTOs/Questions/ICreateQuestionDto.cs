using ExamsApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Questions
{
    public interface ICreateQuestionDto
    {
        [Required]
        public int MainQuestionId { get; set; }
        [Required, Range(0, 1000)]
        public double Marks { get; set; }
        [Required, Range(0, 1000)]
        public int DisplayOrder { get; set; }
    }
}
