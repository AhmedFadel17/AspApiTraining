using ExamsApi.Application.DTOs.HeadingQuestions;

namespace ExamsApi.Application.Interfaces.HeadingQuestions
{
    public interface IHeadingQuestionService
    {
        Task<HeadingQuestionResponseDto> CreateAsync(CreateHeadingQuestionDto dto);
        Task<HeadingQuestionResponseDto> UpdateAsync(int id, UpdateHeadingQuestionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
