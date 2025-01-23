using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models.Questions;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.DataAccess.Repositories.Questions
{
    public class ParagraphRepository : IQuestionRepository
    {
        private readonly ApplicationDbContext _context;
        public ParagraphRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Question> GetAsync(int id)
        {
            var question = await _context.ParagraphQuestions.FindAsync(id);
            return question;
        }

        public async Task<IEnumerable<Question>> GetAllAsync()
        {
            var questions = await _context.ParagraphQuestions.ToListAsync();
            return questions;
        }
        public async Task CreateAsync(Question question)
        {
            _context.ParagraphQuestions.Add(question as Paragraph);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Question question)
        {
            _context.ParagraphQuestions.Update(question as Paragraph);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Question question)
        {
            _context.ParagraphQuestions.Remove(question as Paragraph);
            await _context.SaveChangesAsync();
        }
    }
}
