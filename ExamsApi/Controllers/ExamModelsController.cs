
using Microsoft.AspNetCore.Mvc;
using ExamsApi.DTOs.ExamModel;
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
            try
            {
                var examModels = await _examService.GetAllExamModelAsync();
                return Ok(examModels);
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

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var exam = await _examService.GetExamModelAsync(id);
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
        public async Task<IActionResult> Create(CreateExamModelDto examModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var examModel = await _examService.CreateExamModelAsync(examModelDto);
                return Ok(examModel);
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
        public async Task<IActionResult> Update(int id, UpdateExamModelDto examModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var examModel = await _examService.UpdateExamModelAsync(id,examModelDto);
                return Ok(examModel);
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
                var isDeleted = await _examService.DeleteExamModelAsync(id);
                return Ok(new { message = "Exam Model deleted" });
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
