using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models.Questions;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.DataAccess.Repositories.Questions
{
    public class ParagraphRepository : IParagraphRepository
    {
        private readonly ApplicationDbContext _context;
        public ParagraphRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Paragraph> GetAsync(int id)
        {
            var question = await _context.ParagraphQuestions.FindAsync(id);
            return question;
        }

        public async Task<IEnumerable<Paragraph>> GetAllAsync()
        {
            var questions = await _context.ParagraphQuestions.ToListAsync();
            return questions;
        }
        public async Task CreateAsync(Paragraph question)
        {
            _context.ParagraphQuestions.Add(question);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Paragraph question)
        {
            _context.ParagraphQuestions.Update(question);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Paragraph question)
        {
            _context.ParagraphQuestions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
