using AutoMapper;
using ExamsApi.Data;
using ExamsApi.DTOs.Question.Paragraph;

namespace ExamsApi.Services.Question.Paragraph
{
    public class ParagraphService : IParagraphService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public ParagraphService(ApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
      

        public async Task<ParagraphResponseDto> CreateParagraphAsync(CreateParagraphDto dto)
        {
            var question = _mapper.Map<Models.Questions.Paragraph>(dto);
            _context.ParagraphQuestions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<ParagraphResponseDto>(question);
        }
        public async Task<ParagraphResponseDto> UpdateParagraphAsync(int id, UpdateParagraphDto paragraphDto)
        {
            var question = await _context.ParagraphQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            if (paragraphDto.Marks.HasValue) question.Marks = paragraphDto.Marks.Value;
            if (paragraphDto.MinWords.HasValue) question.MinWords = paragraphDto.MinWords.Value;
            if (paragraphDto.Title != null) question.Title = paragraphDto.Title;
            if (paragraphDto.GuidingWords != null) question.GuidingWords = paragraphDto.GuidingWords;
            await _context.SaveChangesAsync();
            return _mapper.Map<ParagraphResponseDto>(question);
        }
        public async Task<bool> DeleteParagraphAsync(int id)
        {
            var question = await _context.ParagraphQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _context.ParagraphQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
