using ExamsApi.DataAccess.Data;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamsApi.DataAccess.Repositories.ExamModels
{
    public class ExamModelRepository : IExamModelRepository
    {
        private readonly ApplicationDbContext _context;
        public ExamModelRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<ExamModel> GetAsync(int id)
        {
            var exam = await _context.ExamModels.FindAsync(id);
            return exam;
        }

        public async Task<IEnumerable<ExamModel>> GetAllAsync()
        {
            var exams = await _context.ExamModels.ToListAsync();
            return exams;
        }

        public async Task CreateAsync(ExamModel examModel)
        {
            _context.ExamModels.Add(examModel);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(ExamModel examModel)
        {
            _context.ExamModels.Update(examModel);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(ExamModel examModel)
        {
            _context.ExamModels.Remove(examModel);
            await _context.SaveChangesAsync();
        }
    }
}
