using AutoMapper;
using ExamsApi.Data;
using ExamsApi.DTOs.Questions;
using ExamsApi.DTOs.Questions.Paragraph;
using ExamsApi.Services.Questions;

namespace ExamsApi.Services.Question.Paragraph
{
    public class ParagraphService : IQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ParagraphService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      

        public async Task<IQuestionResponseDto> CreateQuestionAsync(ICreateQuestionDto dto)
        {
            var question = _mapper.Map<Models.Questions.Paragraph>(dto);
            _context.ParagraphQuestions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<IQuestionResponseDto>(question);
        }
        public async Task<IQuestionResponseDto> UpdateQuestionAsync(int id, IUpdateQuestionDto dto)
        {
            var question = await _context.ParagraphQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            var paragraphDto = dto as UpdateParagraphDto;
            if (paragraphDto.Marks.HasValue) question.Marks = paragraphDto.Marks.Value;
            if (paragraphDto.MinWords.HasValue) question.MinWords = paragraphDto.MinWords.Value;
            if (paragraphDto.Title != null) question.Title = paragraphDto.Title;
            if (paragraphDto.GuidingWords != null) question.GuidingWords = paragraphDto.GuidingWords;
            await _context.SaveChangesAsync();
            return _mapper.Map<IQuestionResponseDto>(question);
        }
        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.ParagraphQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _context.ParagraphQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
