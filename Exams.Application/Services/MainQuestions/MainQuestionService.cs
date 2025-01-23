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

        public async Task<MainQuestionResponseDto> CreateAsync(CreateMainQuestionDto dto)
        {
            var mainQuestion = _mapper.Map<MainQuestion>(dto);
            _context.MainQuestions.Add(mainQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainQuestionResponseDto>(mainQuestion);
        }
        public async Task<MainQuestionResponseDto> UpdateAsync(int id, UpdateMainQuestionDto mainQuestionDto)
        {
            var mainQuestion = await _context.MainQuestions.FindAsync(id);
            if (mainQuestion == null) throw new KeyNotFoundException("Main Question not found");
            _mapper.Map(mainQuestionDto, mainQuestion);
            await _context.SaveChangesAsync();
            return _mapper.Map<MainQuestionResponseDto>(mainQuestion);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var mainQuestion = await _context.MainQuestions.FindAsync(id);
            if (mainQuestion == null) throw new KeyNotFoundException("Main Question not found");
            _context.MainQuestions.Remove(mainQuestion);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
