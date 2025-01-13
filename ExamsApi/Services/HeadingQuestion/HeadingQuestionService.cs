using AutoMapper;
using ExamsApi.Data;
using ExamsApi.DTOs.HeadingQuestion;
namespace ExamsApi.Services.HeadingQuestion
{
    public class HeadingQuestionService : IHeadingQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public HeadingQuestionService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        

        public async Task<HeadingQuestionResponseDto> CreateHeadingQuestionAsync(CreateHeadingQuestionDto dto)
        {
            var examModel = await _context.HeadingQuestions.FindAsync(dto.ExamModelId);
            if (examModel == null) throw new KeyNotFoundException("Exam Model is not found");
            var headingQuestion = _mapper.Map<Models.HeadingQuestion>(dto);
            _context.HeadingQuestions.Add(headingQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<HeadingQuestionResponseDto>(headingQuestion);
        }
        public async Task<HeadingQuestionResponseDto> UpdateHeadingQuestionAsync(int id, UpdateHeadingQuestionDto dto)
        {
            var headingQuestion = await _context.HeadingQuestions.FindAsync(id);
            if (headingQuestion == null) throw new KeyNotFoundException("Heading Question is not found");
            if (dto.Title != null) headingQuestion.Title = dto.Title;
            if (dto.TotalMarks.HasValue) headingQuestion.TotalMarks = dto.TotalMarks.Value;
            if (dto.DisplayOrder.HasValue) headingQuestion.DisplayOrder = dto.DisplayOrder.Value;
            await _context.SaveChangesAsync();
            return _mapper.Map<HeadingQuestionResponseDto>(headingQuestion);
        }
        public async Task<bool> DeleteHeadingQuestionAsync(int id)
        {
            var headingQuestion = await _context.HeadingQuestions.FindAsync(id);
            if (headingQuestion == null) throw new KeyNotFoundException("Heading Question is not found");
            _context.HeadingQuestions.Remove(headingQuestion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
