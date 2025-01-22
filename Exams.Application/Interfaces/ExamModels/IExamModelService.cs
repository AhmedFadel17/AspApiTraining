using ExamsApi.Application.DTOs.ExamModels;

namespace ExamsApi.Application.Interfaces.ExamModels
{
    public interface IExamModelService
    {
        Task<ExamModelResponseDto> GetAsync(int id);
        Task<IEnumerable<ExamModelResponseDto>> GetAllAsync();
        Task<ExamModelResponseDto> CreateAsync(CreateExamModelDto dto);
        Task<ExamModelResponseDto> UpdateAsync(int id, UpdateExamModelDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
