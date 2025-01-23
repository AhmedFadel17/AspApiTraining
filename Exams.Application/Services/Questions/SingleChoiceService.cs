using AutoMapper;
using ExamsApi.Application.DTOs.Questions.SingleChoice;
using ExamsApi.Application.Interfaces.Questions;
using ExamsApi.DataAccess.Data;
using ExamsApi.Application.DTOs.Questions;
using ExamsApi.Domain.Models.Questions;
using ExamsApi.Application.DTOs.Questions.Paragraph;
namespace ExamsApi.Application.Services.Questions
{
    public class SingleChoiceService : IQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SingleChoiceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IQuestionResponseDto> CreateAsync(ICreateQuestionDto dto)
        {
            var question = _mapper.Map<SingleChoice>(dto);
            _context.SingleChoiceQuestions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<SingleChoiceResponseDto>(question);
        }
        public async Task<IQuestionResponseDto> UpdateAsync(int id, IUpdateQuestionDto dto)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            var singleChoiceDto = dto as UpdateSingleChoiceDto;
            _mapper.Map(singleChoiceDto, question);
            await _context.SaveChangesAsync();
            return _mapper.Map<SingleChoiceResponseDto>(question);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _context.SingleChoiceQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
