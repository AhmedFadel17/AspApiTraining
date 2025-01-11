namespace ExamsApi.Models.Questions
{
    public class Paragraph : Question
    {
        public int MinWords { get; set; }
        public required string Title { get; set; }
        public required string GuidingWords { get; set; }
    }
}
