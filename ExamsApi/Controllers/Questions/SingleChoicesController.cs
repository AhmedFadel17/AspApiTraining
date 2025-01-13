using ExamsApi.DTOs.Question.SingleChoice;
using ExamsApi.Services.Question.SingleChoice;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleChoicesController : ControllerBase
    {
        private readonly ISingleChoiceService _singleChoiceService;

        public SingleChoicesController(ISingleChoiceService singleChoiceService)
        {
            _singleChoiceService=singleChoiceService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateSingleChoiceDto singleChoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var question = await _singleChoiceService.CreateSingleChoiceAsync(singleChoiceDto);
                return Ok(question);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateSingleChoiceDto singleChoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var question = await _singleChoiceService.UpdateSingleChoiceAsync(id,singleChoiceDto);
                return Ok(question);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var isDeleted = await _singleChoiceService.DeleteSingleChoiceAsync(id);
                return Ok(new { message = "Question deleted" });
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }
        }
    }
}
