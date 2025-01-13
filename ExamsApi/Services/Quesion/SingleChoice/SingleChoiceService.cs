using AutoMapper;
using ExamsApi.Data;
using ExamsApi.DTOs.Exam;
using ExamsApi.DTOs.Question.Paragraph;
using ExamsApi.DTOs.Question.SingleChoice;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.Services.Question.SingleChoice
{
    public class SingleChoiceService : ISingleChoiceService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public SingleChoiceService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<SingleChoiceResponseDto> CreateSingleChoiceAsync(CreateSingleChoiceDto dto)
        {
            var question = _mapper.Map<Models.Questions.SingleChoice>(dto);
            _context.SingleChoiceQuestions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<SingleChoiceResponseDto>(question);
        }
        public async Task<SingleChoiceResponseDto> UpdateSingleChoiceAsync(int id, UpdateSingleChoiceDto singleChoiceDto)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            if (singleChoiceDto.Marks.HasValue) question.Marks = singleChoiceDto.Marks.Value;
            if (singleChoiceDto.QuestionText != null) question.QuestionText = singleChoiceDto.QuestionText;
            if (singleChoiceDto.Choice1 != null) question.Choice1 = singleChoiceDto.Choice1;
            if (singleChoiceDto.Choice2 != null) question.Choice2 = singleChoiceDto.Choice2;
            if (singleChoiceDto.Choice3 != null) question.Choice3 = singleChoiceDto.Choice3;
            if (singleChoiceDto.Choice4 != null) question.Choice4 = singleChoiceDto.Choice4;
            if (singleChoiceDto.Answer != null) question.Answer = singleChoiceDto.Answer;

            await _context.SaveChangesAsync();
            return _mapper.Map<SingleChoiceResponseDto>(question);
        }
        public async Task<bool> DeleteSingleChoiceAsync(int id)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _context.SingleChoiceQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
