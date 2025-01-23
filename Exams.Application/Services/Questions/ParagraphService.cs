using AutoMapper;
using ExamsApi.Application.DTOs.Questions.Paragraph;
using ExamsApi.Application.Interfaces.Questions;
using ExamsApi.Domain.Models.Questions;
using ExamsApi.DataAccess.Repositories.Questions;
namespace ExamsApi.Application.Services.Questions
{
    public class ParagraphService : IParagraphService
    {
        private readonly IParagraphRepository _repo;
        private readonly IMapper _mapper;
        public ParagraphService(IParagraphRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<ParagraphResponseDto> CreateAsync(CreateParagraphDto dto)
        {
            var question = _mapper.Map<Paragraph>(dto);
            await _repo.CreateAsync(question);
            return _mapper.Map<ParagraphResponseDto>(question);
        }
        public async Task<ParagraphResponseDto> UpdateAsync(int id, UpdateParagraphDto paragraphDto)
        {
            var question = await _repo.GetAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _mapper.Map(paragraphDto, question);
            await _repo.UpdateAsync(question);
            return _mapper.Map<ParagraphResponseDto>(question);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var question = await _repo.GetAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            await _repo.DeleteAsync(question);
            return true;
        }
    }
}
