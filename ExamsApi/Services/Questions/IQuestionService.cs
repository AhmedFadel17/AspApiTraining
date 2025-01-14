using ExamsApi.DTOs.Questions;

namespace ExamsApi.Services.Questions
{
    public interface IQuestionService
    {
        Task<IQuestionResponseDto> CreateQuestionAsync(ICreateQuestionDto dto);
        Task<IQuestionResponseDto> UpdateQuestionAsync(int id, IUpdateQuestionDto dto);
        Task<bool> DeleteQuestionAsync(int id);
    }
}
