using ExamsApi.Domain.Models;

namespace ExamsApi.DataAccess.Repositories.Questions
{
    public interface IQuestionRepository
    {
        Task<Question> GetAsync(int id);
        Task<IEnumerable<Question>> GetAllAsync();
        Task CreateAsync(Question question);
        Task UpdateAsync(Question question);
        Task DeleteAsync(Question question);
    }
}
