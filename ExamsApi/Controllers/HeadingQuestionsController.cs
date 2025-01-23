using ExamsApi.Application.DTOs.HeadingQuestions;
using ExamsApi.Application.Interfaces.HeadingQuestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.WebUi.Controllers
{
    //[Authorize]
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
        public async Task<IActionResult> Create([FromBody] CreateHeadingQuestionDto headingQuestionDto)
        {
            var headingQuestion = await _headingQuestionService.CreateAsync(headingQuestionDto);
            return Ok(headingQuestion);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateHeadingQuestionDto headingQuestionDto)
        {
            var headingQuestion = await _headingQuestionService.UpdateAsync(id, headingQuestionDto);
            return Ok(headingQuestion);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _headingQuestionService.DeleteAsync(id);
            return Ok(new { message = "Heading Question deleted" });
        }
    }
}
