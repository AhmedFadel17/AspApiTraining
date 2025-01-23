using ExamsApi.Application.DTOs.Questions.SingleChoice;

namespace ExamsApi.Application.Interfaces.Questions
{
    public interface ISingleChoiceService
    {
        Task<SingleChoiceResponseDto> CreateAsync(CreateSingleChoiceDto dto);
        Task<SingleChoiceResponseDto> UpdateAsync(int id, UpdateSingleChoiceDto dto);
        Task<bool> DeleteAsync(int id);
    }
}
