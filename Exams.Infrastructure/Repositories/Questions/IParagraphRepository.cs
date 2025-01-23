using ExamsApi.Domain.Models;
using ExamsApi.Domain.Models.Questions;

namespace ExamsApi.DataAccess.Repositories.Questions
{
    public interface IParagraphRepository
    {
        Task<Paragraph> GetAsync(int id);
        Task<IEnumerable<Paragraph>> GetAllAsync();
        Task CreateAsync(Paragraph paragraph);
        Task UpdateAsync(Paragraph paragraph);
        Task DeleteAsync(Paragraph paragraph);
    }
}
