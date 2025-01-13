using Microsoft.AspNetCore.Mvc;
using ExamsApi.DTOs.ExamModels;
using ExamsApi.Services.ExamModel;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamModelsController : ControllerBase
    {
        private readonly IExamModelService _examService;

        public ExamModelsController(IExamModelService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var examModels = await _examService.GetAllExamModelAsync();
            return Ok(examModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var exam = await _examService.GetExamModelAsync(id);
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamModelDto examModelDto)
        {
            var examModel = await _examService.CreateExamModelAsync(examModelDto);
            return Ok(examModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateExamModelDto examModelDto)
        {
            var examModel = await _examService.UpdateExamModelAsync(id, examModelDto);
            return Ok(examModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _examService.DeleteExamModelAsync(id);
            return Ok(new { message = "Exam Model deleted" });
        }
    }
}
