using ExamsApi.Domain.Models;
using ExamsApi.Domain.Models.Questions;

namespace ExamsApi.DataAccess.Repositories.Questions
{
    public interface ISingleChoicesRepository
    {
        Task<SingleChoice> GetAsync(int id);
        Task<IEnumerable<SingleChoice>> GetAllAsync();
        Task CreateAsync(SingleChoice singleChoice);
        Task UpdateAsync(SingleChoice singleChoice);
        Task DeleteAsync(SingleChoice singleChoice);
    }
}
