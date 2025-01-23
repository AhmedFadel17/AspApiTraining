using ExamsApi.Application.DTOs.Exams;
using Microsoft.AspNetCore.Mvc;
using ExamsApi.Application.Interfaces.Exams;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

namespace ExamsApi.WebUi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IExamService _examService;
        private readonly int _userId;
        public ExamsController(IExamService examService, IHttpContextAccessor httpContextAccessor)
        {
            _examService = examService;
            var userIdClaim = httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out _userId))
            {
                throw new UnauthorizedAccessException("User is not authenticated.");
            }
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var exams = await _examService.GetAllAsync();
            return Ok(exams);
        }

        [HttpGet]
        [Route("{id:int}/questions")]
        public async Task<IActionResult> GetFull(int id)
        {
            var exams = await _examService.GetFullAsync(id);
            return Ok(exams);
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var exam = await _examService.GetAsync(id);
            return Ok(exam);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateExamDto examDto)
        {
            examDto.UserId = _userId;
            var exam = await _examService.CreateAsync(examDto);
            return Ok(exam);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateExamDto examDto)
        {
            var exam = await _examService.UpdateAsync(id, examDto);
            return Ok(exam);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var isDeleted = await _examService.DeleteAsync(id);
            return Ok(new { message = "Exam deleted" });
        }
    }
}
