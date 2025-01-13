using System.Text.Json.Serialization;

namespace ExamsApi.DTOs.ExamModels
{
    public class ExamModelResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExamId { get; set; }
    }
}
