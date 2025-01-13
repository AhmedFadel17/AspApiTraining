using ExamsApi.DTOs.Exams;
using ExamsApi.DTOs.Questions.Paragraph;

namespace ExamsApi.Services.Question.Paragraph
{
    public interface IParagraphService
    {
        Task<ParagraphResponseDto> CreateParagraphAsync(CreateParagraphDto dto);
        Task<ParagraphResponseDto> UpdateParagraphAsync(int id, UpdateParagraphDto dto);
        Task<bool> DeleteParagraphAsync(int id);
    }
}
