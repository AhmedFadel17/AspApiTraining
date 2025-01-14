using System.Text.Json.Serialization;

namespace ExamsApi.Models
{
    public class Exam
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int UserId { get; set; }
        public string? Description { get; set; }
        public int Grade { get; set; }
        public required string Subject { get; set; }
        public int Time { get; set; }
        public double TotalMarks   { get; set; }
        [JsonIgnore]
        public ICollection<ExamModel>? ExamModels { get; set; }
        public User User { get; set; }
    }
}
