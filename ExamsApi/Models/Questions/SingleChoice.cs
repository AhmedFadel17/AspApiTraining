namespace ExamsApi.Models.Questions
{
    public class SingleChoice : Question
    {
        public required string QuestionText { get; set; }
        public required string Choice1 { get; set; }
        public required string Choice2 { get; set; }
        public required string Choice3 { get; set; }
        public required string Choice4 { get; set; }
        public required string Answer { get; set; }
    }
}
