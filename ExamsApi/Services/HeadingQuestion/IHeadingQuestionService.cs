using ExamsApi.DTOs.Exams;
using ExamsApi.DTOs.HeadingQuestions;

namespace ExamsApi.Services.HeadingQuestion
{
    public interface IHeadingQuestionService
    {
        Task<HeadingQuestionResponseDto> CreateHeadingQuestionAsync(CreateHeadingQuestionDto dto);
        Task<HeadingQuestionResponseDto> UpdateHeadingQuestionAsync(int id, UpdateHeadingQuestionDto dto);
        Task<bool> DeleteHeadingQuestionAsync(int id);
    }
}
