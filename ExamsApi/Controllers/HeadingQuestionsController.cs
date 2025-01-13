using ExamsApi.Data;
using ExamsApi.DTOs.ExamModel;
using ExamsApi.DTOs.HeadingQuestion;
using ExamsApi.Models;
using ExamsApi.Services.HeadingQuestion;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadingQuestionsController : ControllerBase
    {
        private readonly IHeadingQuestionService _headingQuestionService;

        public HeadingQuestionsController(IHeadingQuestionService headingQuestionService)
        {
            _headingQuestionService = headingQuestionService;
        }


        [HttpPost]
        public async Task<IActionResult> Create(CreateHeadingQuestionDto headingQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var headingQuestion = await _headingQuestionService.CreateHeadingQuestionAsync(headingQuestionDto);
                return Ok(headingQuestion);
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
        public async Task<IActionResult> Update(int id, UpdateHeadingQuestionDto headingQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var headingQuestion = await _headingQuestionService.UpdateHeadingQuestionAsync(id,headingQuestionDto);
                return Ok(headingQuestion);
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
                var isDeleted = await _headingQuestionService.DeleteHeadingQuestionAsync(id);
                return Ok(new { message = "Heading Question deleted" });
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
