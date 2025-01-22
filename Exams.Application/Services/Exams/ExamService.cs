using AutoMapper;
using ExamsApi.Application.Interfaces.Exams;
using ExamsApi.DataAccess.Data;
using ExamsApi.Application.DTOs.Exams;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.Application.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ExamService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<ExamResponseDto> GetExamAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam Not Found");
            return _mapper.Map<ExamResponseDto>(exam);
        }

        public async Task<IEnumerable<ExamResponseDto>> GetAllExamAsync()
        {
            var exams = await _context.Exams.ToListAsync();
            return _mapper.Map<IEnumerable<ExamResponseDto>>(exams);
        }

        public async Task<ExamResponseDto> CreateExamAsync(CreateExamDto dto)
        {
            var exam = _mapper.Map<Exam>(dto);
            _context.Exams.Add(exam);
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamResponseDto>(exam);
        }
        public async Task<ExamResponseDto> UpdateExamAsync(int id, UpdateExamDto examDto)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam not found");
            if (examDto.Name != null) exam.Name = examDto.Name;
            if (examDto.Description != null) exam.Description = examDto.Description;
            if (examDto.Grade.HasValue) exam.Grade = examDto.Grade.Value;
            if (examDto.Subject != null) exam.Subject = examDto.Subject;
            if (examDto.Time.HasValue) exam.Time = examDto.Time.Value;
            if (examDto.TotalMarks.HasValue) exam.TotalMarks = examDto.TotalMarks.Value;
            await _context.SaveChangesAsync();
            return _mapper.Map<ExamResponseDto>(exam);
        }
        public async Task<bool> DeleteExamAsync(int id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam not found");
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
