namespace ExamsApi.Domain.Models.Questions
{
    public class Paragraph : Question
    {
        public int MinWords { get; set; }
        public required string Title { get; set; }
        public required string GuidingWords { get; set; }
        public override string GetQuestionType() => "Paragraph";
    }
}
