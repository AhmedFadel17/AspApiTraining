using ExamsApi.Models;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.ExamModel
{
    public class CreateExamModelDto
    {
        [Required,MaxLength(255)]
        public required string Name { get; set; }
        [Required]
        public int ExamId { get; set; }
    }
}
