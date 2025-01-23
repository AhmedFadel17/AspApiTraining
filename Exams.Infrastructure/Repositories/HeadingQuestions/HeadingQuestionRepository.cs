using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.DataAccess.Repositories.HeadingQuestions
{
    public class HeadingQuestionRepository : IHeadingQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public HeadingQuestionRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<HeadingQuestion> GetAsync(int id)
        {
            var headingQuestion = await _context.HeadingQuestions.FindAsync(id);
            return headingQuestion;
        }

        public async Task<IEnumerable<HeadingQuestion>> GetAllAsync()
        {
            var headingQuestions = await _context.HeadingQuestions.ToListAsync();
            return headingQuestions;
        }

        public async Task CreateAsync(HeadingQuestion headingQuestion)
        {
            _context.HeadingQuestions.Add(headingQuestion);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(HeadingQuestion headingQuestion)
        {
            _context.HeadingQuestions.Update(headingQuestion);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(HeadingQuestion headingQuestion)
        {
            _context.HeadingQuestions.Remove(headingQuestion);
            await _context.SaveChangesAsync();
        }
    }
}
