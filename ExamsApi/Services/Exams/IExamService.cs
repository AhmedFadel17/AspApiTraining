using ExamsApi.DTOs.Exams;

namespace ExamsApi.Services.Exams
{
    public interface IExamService
    {
        Task<ExamResponseDto> GetExamAsync(int id);
        Task<IEnumerable<ExamResponseDto>> GetAllExamAsync();
        Task<ExamResponseDto> CreateExamAsync(CreateExamDto dto);
        Task<ExamResponseDto> UpdateExamAsync(int id,UpdateExamDto dto);
        Task<bool> DeleteExamAsync(int id);
    }
}
