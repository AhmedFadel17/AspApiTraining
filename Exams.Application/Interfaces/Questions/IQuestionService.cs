using ExamsApi.Application.DTOs.Questions;

namespace ExamsApi.Application.Interfaces.Questions
{
    public interface IQuestionService
    {
        Task<IQuestionResponseDto> CreateQuestionAsync(ICreateQuestionDto dto);
        Task<IQuestionResponseDto> UpdateQuestionAsync(int id, IUpdateQuestionDto dto);
        Task<bool> DeleteQuestionAsync(int id);
    }
}
