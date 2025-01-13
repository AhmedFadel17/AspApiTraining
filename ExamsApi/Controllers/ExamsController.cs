using ExamsApi.DTOs.Exam;
using Microsoft.AspNetCore.Mvc;
using ExamsApi.Services.Exam;
namespace ExamsApi.Controllers
{
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
            var exams= await _examService.GetAllExamAsync();
            return Ok(exams);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var exam = await _examService.GetExamAsync(id);
                return Ok(exam);
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

        [HttpPost]
        public async Task<IActionResult> Create(CreateExamDto examDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var exam = await _examService.CreateExamAsync(examDto);
                return Ok(exam);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An unexpected error occurred.");
            }            
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id,UpdateExamDto examDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var exam = await _examService.UpdateExamAsync(id, examDto);
                return Ok(exam);
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
                var isDeleted = await _examService.DeleteExamAsync(id);
                return Ok(new { message = "Exam deleted" });
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
