using Microsoft.AspNetCore.Mvc;
using ExamsApi.DTOs.Questions.Paragraph;
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
            var question = await _paragraphService.CreateParagraphAsync(paragraphDto);
            return Ok(question);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateParagraphDto paragraphDto)
        {
            var question = await _paragraphService.UpdateParagraphAsync(id, paragraphDto);
            return Ok(question);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _paragraphService.DeleteParagraphAsync(id);
            return Ok(new { message = "Question deleted" });
        }
    }
}
