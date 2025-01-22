using ExamsApi.Application.DTOs.HeadingQuestions;

namespace ExamsApi.Application.Interfaces.HeadingQuestions
{
    public interface IHeadingQuestionService
    {
        Task<HeadingQuestionResponseDto> CreateHeadingQuestionAsync(CreateHeadingQuestionDto dto);
        Task<HeadingQuestionResponseDto> UpdateHeadingQuestionAsync(int id, UpdateHeadingQuestionDto dto);
        Task<bool> DeleteHeadingQuestionAsync(int id);
    }
}
