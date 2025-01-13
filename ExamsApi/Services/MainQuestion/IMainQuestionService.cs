using ExamsApi.DTOs.MainQuestions;

namespace ExamsApi.Services.MainQuestion
{
    public interface IMainQuestionService
    {
        Task<MainQuestionResponseDto> CreateMainQuestionAsync(CreateMainQuestionDto dto);
        Task<MainQuestionResponseDto> UpdateMainQuestionAsync(int id, UpdateMainQuestionDto dto);
        Task<bool> DeleteMainQuestionAsync(int id);
    }
}
