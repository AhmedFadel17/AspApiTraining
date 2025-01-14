using ExamsApi.Data;
using ExamsApi.DTOs.HeadingQuestions;
using ExamsApi.Services.HeadingQuestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers
{
    [Authorize]
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
            var headingQuestion = await _headingQuestionService.CreateHeadingQuestionAsync(headingQuestionDto);
            return Ok(headingQuestion);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateHeadingQuestionDto headingQuestionDto)
        {
            var headingQuestion = await _headingQuestionService.UpdateHeadingQuestionAsync(id, headingQuestionDto);
            return Ok(headingQuestion);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _headingQuestionService.DeleteHeadingQuestionAsync(id);
            return Ok(new { message = "Heading Question deleted" });
        }
    }
}
