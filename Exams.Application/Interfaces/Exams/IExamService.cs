using ExamsApi.Application.DTOs.Exams;

namespace ExamsApi.Application.Interfaces.Exams
{
    public interface IExamService
    {
        Task<ExamResponseDto> GetAsync(int id);
        Task<FullExamResponseDto> GetFullAsync(int id);
        Task<IEnumerable<ExamResponseDto>> GetAllAsync();
        Task<ExamResponseDto> CreateAsync(CreateExamDto dto);
        Task<ExamResponseDto> UpdateAsync(int id, UpdateExamDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
