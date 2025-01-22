using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.ExamModels
{
    public record UpdateExamModelDto
    {
        [Required, MaxLength(255)]
        public required string Name { get; set; }
    }
}
