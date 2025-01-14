using AutoMapper;
using ExamsApi.Data;
using ExamsApi.DTOs.Exams;
using ExamsApi.DTOs.ExamModels;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.Services.ExamModels
{
    public class ExamModelService : IExamModelService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExamModelService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExamModelResponseDto> GetExamModelAsync(int id)
        {
            var exam = await _context.ExamModels.FindAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam Model Not Found");
            return _mapper.Map<ExamModelResponseDto>(exam);
        }

        public async Task<IEnumerable<ExamModelResponseDto>> GetAllExamModelAsync()
        {
            var exams = await _context.ExamModels.ToListAsync();
            return _mapper.Map<IEnumerable<ExamModelResponseDto>>(exams);
        }

        public async Task<ExamModelResponseDto> CreateExamModelAsync(CreateExamModelDto dto)
        {
            var exam = await _context.Exams.FindAsync(dto.ExamId);
            if (exam == null) throw new KeyNotFoundException("Exam not found");
            var examModel = _mapper.Map<Models.ExamModel>(dto);
            _context.ExamModels.Add(examModel);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamModelResponseDto>(examModel);
        }
        public async Task<ExamModelResponseDto> UpdateExamModelAsync(int id, UpdateExamModelDto dto)
        {
            var examModel = await _context.ExamModels.FindAsync(id);
            if (examModel == null) throw new KeyNotFoundException("Exam Model not found");
            examModel.Name = dto.Name;
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamModelResponseDto>(examModel);
        }
        public async Task<bool> DeleteExamModelAsync(int id)
        {
            var examModel = await _context.ExamModels.FindAsync(id);
            if (examModel == null) throw new KeyNotFoundException("Exam Model not found");
            _context.ExamModels.Remove(examModel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
