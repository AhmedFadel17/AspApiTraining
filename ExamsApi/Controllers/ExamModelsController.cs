using ExamsApi.DTOs.Exam;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamsApi.Data;
using ExamsApi.DTOs.ExamModel;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamModelsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamModelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            List<ExamModel> examModels = _context.ExamModels.ToList();
            return Ok(examModels);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            ExamModel? examModel = _context.ExamModels.Find(id);
            if (examModel == null)
            {
                return BadRequest("Exam Model Not Found");
            }
            return Ok(examModel);
        }

        [HttpPost]
        public IActionResult Create(CreateExamModelDto examModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exam? exam = _context.Exams.Find(examModelDto.ExamId);
            if (exam == null)
            {
                return BadRequest("Exam Not Found");
            }
            ExamModel? examModel = new ExamModel
            {
                Name = examModelDto.Name,
                ExamId = examModelDto.ExamId,
            };
            _context.ExamModels.Add(examModel);
            _context.SaveChanges();
            return Ok(examModel);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateExamModelDto examModelDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExamModel? examModel = _context.ExamModels.Find(id);
            if (examModel == null)
            {
                return BadRequest("Exam Model Not Found");
            }

            examModel.Name = examModelDto.Name;

            _context.SaveChanges();
            return Ok(examModel);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            ExamModel? examModel = _context.ExamModels.Find(id);
            if (examModel == null)
            {
                return BadRequest("Exam Model Not Found");
            }
            _context.ExamModels.Remove(examModel);
            _context.SaveChanges();
            return Ok(new { message = "Exam Model deleted" });
        }
    }
}
