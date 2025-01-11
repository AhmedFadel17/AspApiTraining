namespace ExamsApi.DTOs.Question.Paragraph
{
    public class ParagraphResponseDto
    {
        public int Id { get; set; }
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
        public int MinWords { get; set; }
        public string Title { get; set; }
        public string GuidingWords { get; set; }
    }
}
