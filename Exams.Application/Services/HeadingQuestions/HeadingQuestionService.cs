using AutoMapper;
using ExamsApi.Application.Interfaces.HeadingQuestions;
using ExamsApi.DataAccess.Data;
using ExamsApi.Application.DTOs.HeadingQuestions;
using ExamsApi.Domain.Models;
namespace ExamsApi.Application.Services.HeadingQuestions
{
    public class HeadingQuestionService : IHeadingQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HeadingQuestionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<HeadingQuestionResponseDto> CreateAsync(CreateHeadingQuestionDto dto)
        {
            var examModel = await _context.ExamModels.FindAsync(dto.ExamModelId);
            if (examModel == null) throw new KeyNotFoundException("Exam Model is not found");
            var headingQuestion = _mapper.Map<HeadingQuestion>(dto);
            _context.HeadingQuestions.Add(headingQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<HeadingQuestionResponseDto>(headingQuestion);
        }
        public async Task<HeadingQuestionResponseDto> UpdateAsync(int id, UpdateHeadingQuestionDto dto)
        {
            var headingQuestion = await _context.HeadingQuestions.FindAsync(id);
            if (headingQuestion == null) throw new KeyNotFoundException("Heading Question is not found");
            _mapper.Map(dto, headingQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<HeadingQuestionResponseDto>(headingQuestion);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var headingQuestion = await _context.HeadingQuestions.FindAsync(id);
            if (headingQuestion == null) throw new KeyNotFoundException("Heading Question is not found");
            _context.HeadingQuestions.Remove(headingQuestion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
