using ExamsApi.Application.DTOs.MainQuestions;

namespace ExamsApi.Application.Interfaces.MainQuestions
{
    public interface IMainQuestionService
    {
        Task<MainQuestionResponseDto> CreateAsync(CreateMainQuestionDto dto);
        Task<MainQuestionResponseDto> UpdateAsync(int id, UpdateMainQuestionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
