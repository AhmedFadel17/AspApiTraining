using System.Text.Json.Serialization;

namespace ExamsApi.Models
{
    public class MainQuestion
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public int HeadingQuestionId { get; set; }
        public double TotalMarks { get; set; }
        public int DisplayOrder { get; set; }
        public string? Description { get; set; }
        [JsonIgnore]
        public HeadingQuestion? HeadingQuestion { get; set; }
        [JsonIgnore]
        public ICollection<Question>? Questions { get; set; }
    }
}
