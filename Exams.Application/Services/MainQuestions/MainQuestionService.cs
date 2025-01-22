using AutoMapper;
using ExamsApi.Application.Interfaces.MainQuestions;
using ExamsApi.DataAccess.Data;
using ExamsApi.Application.DTOs.MainQuestions;
using ExamsApi.Domain.Models;

namespace ExamsApi.Application.Services.MainQuestions
{
    public class MainQuestionService : IMainQuestionService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public MainQuestionService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<MainQuestionResponseDto> CreateMainQuestionAsync(CreateMainQuestionDto dto)
        {
            var mainQuestion = _mapper.Map<MainQuestion>(dto);
            _context.MainQuestions.Add(mainQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainQuestionResponseDto>(mainQuestion);
        }
        public async Task<MainQuestionResponseDto> UpdateMainQuestionAsync(int id, UpdateMainQuestionDto mainQuestionDto)
        {
            var mainQuestion = await _context.MainQuestions.FindAsync(id);
            if (mainQuestion == null) throw new KeyNotFoundException("Main Question not found");
            if (mainQuestionDto.Title != null) mainQuestion.Title = mainQuestionDto.Title;
            if (mainQuestionDto.TotalMarks.HasValue) mainQuestion.TotalMarks = mainQuestionDto.TotalMarks.Value;
            if (mainQuestionDto.DisplayOrder.HasValue) mainQuestion.DisplayOrder = mainQuestionDto.DisplayOrder.Value;
            if (mainQuestionDto.Description != null) mainQuestion.Description = mainQuestionDto.Description;
            await _context.SaveChangesAsync();
            return _mapper.Map<MainQuestionResponseDto>(mainQuestion);
        }
        public async Task<bool> DeleteMainQuestionAsync(int id)
        {
            var mainQuestion = await _context.MainQuestions.FindAsync(id);
            if (mainQuestion == null) throw new KeyNotFoundException("Main Question not found");
            _context.MainQuestions.Remove(mainQuestion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
