using ExamsApi.Application.DTOs.Questions;

namespace ExamsApi.Application.Interfaces.Questions
{
    public interface IQuestionService
    {
        Task<IQuestionResponseDto> CreateAsync(ICreateQuestionDto dto);
        Task<IQuestionResponseDto> UpdateAsync(int id, IUpdateQuestionDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
