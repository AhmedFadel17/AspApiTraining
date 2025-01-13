using ExamsApi.DTOs.Exam;
using ExamsApi.DTOs.HeadingQuestion;

namespace ExamsApi.Services.HeadingQuestion
{
    public interface IHeadingQuestionService
    {
        Task<HeadingQuestionResponseDto> CreateHeadingQuestionAsync(CreateHeadingQuestionDto dto);
        Task<HeadingQuestionResponseDto> UpdateHeadingQuestionAsync(int id, UpdateHeadingQuestionDto dto);
        Task<bool> DeleteHeadingQuestionAsync(int id);
    }
}
