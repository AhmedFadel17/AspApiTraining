using ExamsApi.DTOs.Exams;
using Microsoft.AspNetCore.Mvc;
using ExamsApi.Services.Exams;
using Microsoft.AspNetCore.Authorization;

namespace ExamsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;

        public ExamsController(IExamService examService)
        {
            _examService = examService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var exams = await _examService.GetAllExamAsync();
            return Ok(exams);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var exam = await _examService.GetExamAsync(id);
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto examDto)
        {
            var exam = await _examService.CreateExamAsync(examDto);
            return Ok(exam);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateExamDto examDto)
        {
            var exam = await _examService.UpdateExamAsync(id, examDto);
            return Ok(exam);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _examService.DeleteExamAsync(id);
            return Ok(new { message = "Exam deleted" });
        }
    }
}
