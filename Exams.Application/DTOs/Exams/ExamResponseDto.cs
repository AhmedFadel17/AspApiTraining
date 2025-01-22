namespace ExamsApi.Application.DTOs.Exams
{
    public record ExamResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Grade { get; set; }
        public string Subject { get; set; }
        public int Time { get; set; }
        public double TotalMarks { get; set; }
    }
}
