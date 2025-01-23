using ExamsApi.Domain.Models;

namespace ExamsApi.DataAccess.Repositories.HeadingQuestions
{
    public interface IHeadingQuestionRepository
    {
        Task<HeadingQuestion> GetAsync(int id);
        Task<IEnumerable<HeadingQuestion>> GetAllAsync();
        Task CreateAsync(HeadingQuestion headingQuestion);
        Task UpdateAsync(HeadingQuestion headingQuestion);
        Task DeleteAsync(HeadingQuestion headingQuestion);
    }
}
