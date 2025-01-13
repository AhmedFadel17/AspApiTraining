using System.Text.Json.Serialization;

namespace ExamsApi.Models
{
    public abstract class Question
    {
        public int Id { get; set; }
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
        [JsonIgnore]
        public MainQuestion? MainQuestion { get; set; }
        public abstract string GetQuestionType();
    }
}
