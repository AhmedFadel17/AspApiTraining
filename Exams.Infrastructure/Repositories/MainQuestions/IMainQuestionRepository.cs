using ExamsApi.Domain.Models;

namespace ExamsApi.DataAccess.Repositories.MainQuestions
{
    public interface IMainQuestionRepository
    {
        Task<MainQuestion> GetAsync(int id);
        Task<IEnumerable<MainQuestion>> GetAllAsync();
        Task CreateAsync(MainQuestion mainQuestion);
        Task UpdateAsync(MainQuestion mainQuestion);
        Task DeleteAsync(MainQuestion mainQuestion);
    }
}
