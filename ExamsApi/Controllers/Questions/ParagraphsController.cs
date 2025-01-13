using Microsoft.AspNetCore.Mvc;
using ExamsApi.DTOs.Question.Paragraph;
using ExamsApi.Services.Question.Paragraph;

namespace ExamsApi.Controllers.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParagraphsController : ControllerBase
    {
        private readonly IParagraphService _paragraphService;

        public ParagraphsController(IParagraphService paragraphService)
        {
            _paragraphService = paragraphService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateParagraphDto paragraphDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var question = await _paragraphService.CreateParagraphAsync(paragraphDto);
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
        public async Task<IActionResult> UpdateAsync(int id, UpdateParagraphDto paragraphDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var question = await _paragraphService.UpdateParagraphAsync(id,paragraphDto);
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
                var isDeleted = await _paragraphService.DeleteParagraphAsync(id);
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
