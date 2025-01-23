using AutoMapper;
using ExamsApi.Application.DTOs.Questions.SingleChoice;
using ExamsApi.Application.Interfaces.Questions;
using ExamsApi.DataAccess.Data;
using ExamsApi.DataAccess.Repositories.Questions;
using ExamsApi.Domain.Models.Questions;
namespace ExamsApi.Application.Services.Questions
{
    public class SingleChoiceService : ISingleChoiceService
    {
        private readonly ISingleChoicesRepository _repo;
        private readonly IMapper _mapper;
        public SingleChoiceService(ISingleChoicesRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }


        public async Task<SingleChoiceResponseDto> CreateAsync(CreateSingleChoiceDto dto)
        {
            var question = _mapper.Map<SingleChoice>(dto);
            await _repo.CreateAsync(question);
            return _mapper.Map<SingleChoiceResponseDto>(question);
        }
        public async Task<SingleChoiceResponseDto> UpdateAsync(int id, UpdateSingleChoiceDto dto)
        {
            var question = await _repo.GetAsync(id);
            if (question == null) throw new KeyNotFoundException("Question not found");
            _mapper.Map(dto, question);
            await _repo.UpdateAsync(question);
            return _mapper.Map<SingleChoiceResponseDto>(question);
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
