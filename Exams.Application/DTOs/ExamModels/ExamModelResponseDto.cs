using System.Text.Json.Serialization;

namespace ExamsApi.Application.DTOs.ExamModels
{
    public record ExamModelResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int ExamId { get; set; }
    }
}
