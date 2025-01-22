using ExamsApi.Application.DTOs.Questions.SingleChoice;
using ExamsApi.Application.Interfaces.Questions;
using ExamsApi.Application.Services.Questions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.WebUi.Controllers.Questions
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SingleChoicesController : ControllerBase
    {
        private readonly IQuestionService _singleChoiceService;

        public SingleChoicesController(SingleChoiceService singleChoiceService)
        {
            _singleChoiceService = singleChoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateSingleChoiceDto singleChoiceDto)
        {
            var question = await _singleChoiceService.CreateAsync(singleChoiceDto);
            return Ok(question);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateSingleChoiceDto singleChoiceDto)
        {
            var question = await _singleChoiceService.UpdateAsync(id, singleChoiceDto);
            return Ok(question);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _singleChoiceService.DeleteAsync(id);
            return Ok(new { message = "Question deleted" });
        }
    }
}
