using ExamsApi.DTOs.MainQuestion;
using ExamsApi.Services.MainQuestion;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainQuestionsController : ControllerBase
    {
        private readonly IMainQuestionService _mainQuestionService;

        public MainQuestionsController(IMainQuestionService mainQuestionService)
        {
            _mainQuestionService = mainQuestionService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateMainQuestionDto mainQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var mainQuestion = await _mainQuestionService.CreateMainQuestionAsync(mainQuestionDto);
                return Ok(mainQuestion);
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
        public async Task<IActionResult> Update(int id, UpdateMainQuestionDto mainQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var mainQuestion = await _mainQuestionService.UpdateMainQuestionAsync(id, mainQuestionDto);
                return Ok(mainQuestion);
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
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var isDeleted = await _mainQuestionService.DeleteMainQuestionAsync(id);
                return Ok(new { message = "Main Question deleted" });
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
