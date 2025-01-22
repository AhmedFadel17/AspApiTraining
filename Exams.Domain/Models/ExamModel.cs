using System.Text.Json.Serialization;

namespace ExamsApi.Domain.Models
{
    public class ExamModel
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int ExamId { get; set; }
        [JsonIgnore]
        public Exam? Exam { get; set; }
        [JsonIgnore]
        public ICollection<HeadingQuestion>? HeadingQuestions { get; set; }
    }
}
