using ExamsApi.Data;
using ExamsApi.DTOs.Exam;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ExamsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult All()
        {
            List<Exam> exams= _context.Exams.ToList();
            return Ok(exams);
        }

        [HttpGet]
        [Route("{id:int}")]
        public IActionResult Get(int id)
        {
            Exam? exam = _context.Exams.Find(id);
            if (exam == null)
            {
                return BadRequest("Exam Not Found");
            }
            return Ok(exam);
        }

        [HttpPost]
        public IActionResult Create(CreateExamDto examDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exam? exam = new Exam
            {
                Name = examDto.Name,
                Description = examDto.Description,
                Time = examDto.Time,
                Grade = examDto.Grade,
                Subject = examDto.Subject,
                TotalMarks = examDto.TotalMarks,
            };
            _context.Exams.Add(exam);
            _context.SaveChanges();
            return Ok(exam);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id,UpdateExamDto examDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Exam? exam = _context.Exams.Find(id);
            if (exam == null) {
                return BadRequest("Exam Not Found");
            }

            if (examDto.Name != null) exam.Name = examDto.Name;
            if (examDto.Description != null) exam.Description = examDto.Description;
            if (examDto.Grade.HasValue) exam.Grade = examDto.Grade.Value;
            if (examDto.Subject != null) exam.Subject = examDto.Subject;
            if (examDto.Time.HasValue) exam.Time = examDto.Time.Value;
            if (examDto.TotalMarks.HasValue) exam.TotalMarks = examDto.TotalMarks.Value;

            _context.SaveChanges();
            return Ok(exam);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            Exam? exam = _context.Exams.Find(id);
            if (exam == null)
            {
                return BadRequest("Exam Not Found");
            }
            _context.Exams.Remove(exam);
            _context.SaveChanges();
            return Ok(new {message="Exam deleted" });
        }
    }
}
