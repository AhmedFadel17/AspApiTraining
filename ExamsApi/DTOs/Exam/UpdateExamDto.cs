using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Exam
{
    public class UpdateExamDto
    {
        [MaxLength(255)]
        public string? Name { get; set; }
        [MaxLength(455)]
        public string? Description { get; set; }
        [Range(1, 1000)]
        public int? Grade { get; set; }
        [MaxLength(255)]
        public string? Subject { get; set; }
        [Range(0, 2500)]
        public int? Time { get; set; }
        [Range(0, 1000)]
        public double? TotalMarks { get; set; }
    }
}
