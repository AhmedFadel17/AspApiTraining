using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.ExamModels
{
    public record CreateExamModelDto
    {
        [Required, MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        public int ExamId { get; set; }
    }
}
