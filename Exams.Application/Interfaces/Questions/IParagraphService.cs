using ExamsApi.Application.DTOs.Questions.Paragraph;

namespace ExamsApi.Application.Interfaces.Questions
{
    public interface IParagraphService
    {
        Task<ParagraphResponseDto> CreateAsync(CreateParagraphDto dto);
        Task<ParagraphResponseDto> UpdateAsync(int id, UpdateParagraphDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
