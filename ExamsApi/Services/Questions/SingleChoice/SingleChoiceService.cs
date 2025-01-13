using AutoMapper;
using ExamsApi.Data;
using ExamsApi.DTOs.Exams;
using ExamsApi.DTOs.Questions;
using ExamsApi.DTOs.Questions.Paragraph;
using ExamsApi.DTOs.Questions.SingleChoice;
using ExamsApi.Models;
using ExamsApi.Services.Questions;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
namespace ExamsApi.Services.Question.SingleChoice
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


        public async Task<IQuestionResponseDto> CreateQuestionAsync(ICreateQuestionDto dto)
        {
            var question = _mapper.Map<Models.Questions.SingleChoice>(dto);
            _context.SingleChoiceQuestions.Add(question);
            await _context.SaveChangesAsync();
            return _mapper.Map<SingleChoiceResponseDto>(question);
        }
        public async Task<IQuestionResponseDto> UpdateQuestionAsync(int id, IUpdateQuestionDto dto)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");

            // Check if the dto is of type UpdateSingleChoiceDto and cast it
            if (dto is UpdateSingleChoiceDto singleChoiceDto)
            {
                // Now you can safely access the properties of UpdateSingleChoiceDto
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

            // If the DTO is not of type UpdateSingleChoiceDto, you can handle it here or throw an exception if needed
            throw new InvalidCastException("Invalid DTO type");
        }

        public async Task<bool> DeleteQuestionAsync(int id)
        {
            var question = await _context.SingleChoiceQuestions.FindAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _context.SingleChoiceQuestions.Remove(question);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
