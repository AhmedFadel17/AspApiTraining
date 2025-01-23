using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.DataAccess.Repositories.Exams
{
    public class ExamRepository : IExamRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<Exam> GetAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            return exam;
        }
        public async Task<Exam> GetFullAsync(int id)
        {
            var exam = await _context.Exams
                .Include(e => e.ExamModels)
                .ThenInclude(e => e.HeadingQuestions)
                .ThenInclude(e => e.MainQuestions)
                .ThenInclude(e => e.Questions)
                .FirstOrDefaultAsync(e => e.Id == id);
            return exam;
        }

        public async Task<IEnumerable<Exam>> GetAllAsync()
        {
            var exams = await _context.Exams.ToListAsync();
            return exams;
        }

        public async Task CreateAsync(Exam exam)
        {
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Exam exam)
        {
            _context.Exams.Update(exam);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Exam exam)
        {

            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
        }
    }
}
