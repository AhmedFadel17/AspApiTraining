using ExamsApi.Application.DTOs.MainQuestions;
using ExamsApi.Application.Interfaces.MainQuestions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.WebUi.Controllers
{
    [Authorize]
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
            var mainQuestion = await _mainQuestionService.CreateMainQuestionAsync(mainQuestionDto);
            return Ok(mainQuestion);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateMainQuestionDto mainQuestionDto)
        {
            var mainQuestion = await _mainQuestionService.UpdateMainQuestionAsync(id, mainQuestionDto);
            return Ok(mainQuestion);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _mainQuestionService.DeleteMainQuestionAsync(id);
            return Ok(new { message = "Main Question deleted" });
        }
    }
}
