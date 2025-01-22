using ExamsApi.Application.DTOs.ExamModels;

namespace ExamsApi.Application.Interfaces.ExamModels
{
    public interface IExamModelService
    {
        Task<ExamModelResponseDto> GetExamModelAsync(int id);
        Task<IEnumerable<ExamModelResponseDto>> GetAllExamModelAsync();
        Task<ExamModelResponseDto> CreateExamModelAsync(CreateExamModelDto dto);
        Task<ExamModelResponseDto> UpdateExamModelAsync(int id, UpdateExamModelDto dto);
        Task<bool> DeleteExamModelAsync(int id);
    }
}
