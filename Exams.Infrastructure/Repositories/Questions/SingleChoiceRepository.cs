using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models.Questions;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.DataAccess.Repositories.Questions
{
    public class SingleChoiceRepository : ISingleChoicesRepository
    {
        private readonly ApplicationDbContext _context;
        public SingleChoiceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<SingleChoice> GetAsync(int id)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            return question;
        }

        public async Task<IEnumerable<SingleChoice>> GetAllAsync()
        {
            var questions = await _context.SingleChoiceQuestions.ToListAsync();
            return questions;
        }

        public async Task CreateAsync(SingleChoice question)
        {
            _context.SingleChoiceQuestions.Add(question);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(SingleChoice question)
        {
            _context.SingleChoiceQuestions.Update(question);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(SingleChoice question)
        {
            _context.SingleChoiceQuestions.Remove(question);
            await _context.SaveChangesAsync();
        }
    }
}
