using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.Exams
{
    public class CreateExamDto
    {
        [Required, MaxLength(255)]
        public required string Name { get; set; }
        [Required, MaxLength(455)]
        public required string Description { get; set; }
        [Required, Range(1, 1000)]
        public int Grade { get; set; }
        [Required, MaxLength(255)]
        public required string Subject { get; set; }
        [Required, Range(0, 2500)]
        public int Time { get; set; }
        [Required, Range(0, 1000)]
        public double TotalMarks { get; set; }
        public int UserId { get; set; }
    }
}
