using ExamsApi.DTOs.Question.SingleChoice;

namespace ExamsApi.Services.Question.SingleChoice
{
    public interface ISingleChoiceService
    {
        Task<SingleChoiceResponseDto> CreateSingleChoiceAsync(CreateSingleChoiceDto dto);
        Task<SingleChoiceResponseDto> UpdateSingleChoiceAsync(int id, UpdateSingleChoiceDto dto);
        Task<bool> DeleteSingleChoiceAsync(int id);
    }
}
