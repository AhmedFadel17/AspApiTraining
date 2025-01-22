using Microsoft.AspNetCore.Mvc;
using ExamsApi.Application.DTOs.ExamModels;
using ExamsApi.Application.Interfaces.ExamModels;
using Microsoft.AspNetCore.Authorization;

namespace ExamsApi.WebUi.Controllers
{
    [Authorize]
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
            var examModels = await _examService.GetAllAsync();
            return Ok(examModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var exam = await _examService.GetAsync(id);
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamModelDto examModelDto)
        {
            var examModel = await _examService.CreateAsync(examModelDto);
            return Ok(examModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateExamModelDto examModelDto)
        {
            var examModel = await _examService.UpdateAsync(id, examModelDto);
            return Ok(examModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _examService.DeleteAsync(id);
            return Ok(new { message = "Exam Model deleted" });
        }
    }
}
