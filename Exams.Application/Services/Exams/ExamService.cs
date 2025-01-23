using AutoMapper;
using ExamsApi.Application.Interfaces.Exams;
using ExamsApi.DataAccess.Data;
using ExamsApi.Application.DTOs.Exams;
using ExamsApi.Domain.Models;
using Microsoft.EntityFrameworkCore;
using ExamsApi.DataAccess.Repositories.Exams;
namespace ExamsApi.Application.Services.Exams
{
    public class ExamService : IExamService
    {
        private readonly IExamRepository _repo;
        private readonly IMapper _mapper;
        public ExamService(IExamRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        public async Task<FullExamResponseDto> GetFullAsync(int id)
        {
            var exam = await _repo.GetFullAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam Not Found");
            return _mapper.Map<FullExamResponseDto>(exam);
        }

        public async Task<ExamResponseDto> GetAsync(int id)
        {
            var exam = await _repo.GetAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam Not Found");
            return _mapper.Map<ExamResponseDto>(exam);
        }

        public async Task<IEnumerable<ExamResponseDto>> GetAllAsync()
        {
            var exams = await _repo.GetAllAsync();
            return _mapper.Map<IEnumerable<ExamResponseDto>>(exams);
        }

        public async Task<ExamResponseDto> CreateAsync(CreateExamDto dto)
        {
            var exam = _mapper.Map<Exam>(dto);
            await _repo.CreateAsync(exam);
            return _mapper.Map<ExamResponseDto>(exam);
        }
        public async Task<ExamResponseDto> UpdateAsync(int id, UpdateExamDto examDto)
        {
            var exam = await _repo.GetAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam not found");
            _mapper.Map(examDto, exam);
            await _repo.UpdateAsync(exam);
            return _mapper.Map<ExamResponseDto>(exam);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var exam = await _repo.GetAsync(id);
            if (exam == null) throw new KeyNotFoundException("Exam not found");
            await _repo.DeleteAsync(exam);
            return true;
        }
    }
}
