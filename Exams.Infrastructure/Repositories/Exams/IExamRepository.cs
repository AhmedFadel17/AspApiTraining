using ExamsApi.Domain.Models;

namespace ExamsApi.DataAccess.Repositories.Exams
{
    public interface IExamRepository
    {
        Task<Exam> GetAsync(int id);
        Task<Exam> GetFullAsync(int id);
        Task<IEnumerable<Exam>> GetAllAsync();
        Task CreateAsync(Exam exam);
        Task UpdateAsync(Exam exam);
        Task DeleteAsync(Exam exam);
    }
}
