using System.Text.Json.Serialization;

namespace ExamsApi.Domain.Models
{
    public class HeadingQuestion
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int ExamModelId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
        [JsonIgnore]
        public ExamModel? ExamModel { get; set; }
        [JsonIgnore]
        public ICollection<MainQuestion>? MainQuestions { get; set; }

    }
}
