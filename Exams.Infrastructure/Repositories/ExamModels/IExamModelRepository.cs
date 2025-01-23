using ExamsApi.Domain.Models;

namespace ExamsApi.DataAccess.Repositories.ExamModels
{
    public interface IExamModelRepository
    {
        Task<ExamModel> GetAsync(int id);
        Task<IEnumerable<ExamModel>> GetAllAsync();
        Task CreateAsync(ExamModel examModel);
        Task UpdateAsync(ExamModel examModel);
        Task DeleteAsync(ExamModel examModel);
    }
}
