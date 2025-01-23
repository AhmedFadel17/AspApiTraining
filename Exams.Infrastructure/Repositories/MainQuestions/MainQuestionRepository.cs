using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamsApi.DataAccess.Repositories.MainQuestions
{
    public class MainQuestionRepository : IMainQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public MainQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<MainQuestion> GetAsync(int id)
        {
            var mainQuestion = await _context.MainQuestions.FindAsync(id);
            return mainQuestion;
        }

        public async Task<IEnumerable<MainQuestion>> GetAllAsync()
        {
            var mainQuestions = await _context.MainQuestions.ToListAsync();
            return mainQuestions;
        }
        public async Task CreateAsync(MainQuestion mainQuestion)
        {
            _context.MainQuestions.Add(mainQuestion);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(MainQuestion mainQuestion)
        {
            _context.MainQuestions.Update(mainQuestion);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(MainQuestion mainQuestion)
        {
            _context.MainQuestions.Remove(mainQuestion);
            await _context.SaveChangesAsync();
        }
    }
}
