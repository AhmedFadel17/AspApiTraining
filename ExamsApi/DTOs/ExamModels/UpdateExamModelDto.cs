using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.ExamModels
{
    public class UpdateExamModelDto
    {
        [Required, MaxLength(255)]
        public required string Name { get; set; }
    }
}
