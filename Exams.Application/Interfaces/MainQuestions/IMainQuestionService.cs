using ExamsApi.Application.DTOs.MainQuestions;

namespace ExamsApi.Application.Interfaces.MainQuestions
{
    public interface IMainQuestionService
    {
        Task<MainQuestionResponseDto> CreateMainQuestionAsync(CreateMainQuestionDto dto);
        Task<MainQuestionResponseDto> UpdateMainQuestionAsync(int id, UpdateMainQuestionDto dto);
        Task<bool> DeleteMainQuestionAsync(int id);
    }
}
