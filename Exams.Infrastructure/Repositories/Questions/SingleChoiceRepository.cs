using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models.Questions;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.DataAccess.Repositories.Questions
{
    public class SingleChoiceRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public SingleChoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Question> GetAsync(int id)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            return question;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            var questions = await _context.SingleChoiceQuestions.ToListAsync();
            return questions;
        }

        public async Task CreateAsync(Question question)
        {
            _context.SingleChoiceQuestions.Add(question as SingleChoice);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Question question)
        {
            _context.SingleChoiceQuestions.Update(question as SingleChoice);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Question question)
        {
            _context.SingleChoiceQuestions.Remove(question as SingleChoice);
            await _context.SaveChangesAsync();
        }
    }
}
