using ExamsApi.DTOs.Exams;
using ExamsApi.DTOs.HeadingQuestions;

namespace ExamsApi.Services.HeadingQuestions
{
    public interface IHeadingQuestionService
    {
        Task<HeadingQuestionResponseDto> CreateHeadingQuestionAsync(CreateHeadingQuestionDto dto);
        Task<HeadingQuestionResponseDto> UpdateHeadingQuestionAsync(int id, UpdateHeadingQuestionDto dto);
        Task<bool> DeleteHeadingQuestionAsync(int id);
    }
}
