using ExamsApi.Data;
using ExamsApi.DTOs.HeadingQuestion;
using ExamsApi.DTOs.MainQuestion;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MainQuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MainQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(CreateMainQuestionDto mainQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HeadingQuestion? headingQuestion = _context.HeadingQuestions.Find(mainQuestionDto.HeadingQuestionId);
            if (headingQuestion == null)
            {
                return BadRequest("Heading Question Not Found");
            }
            MainQuestion mainQuestion = new MainQuestion
            {
                Title = mainQuestionDto.Title,
                HeadingQuestionId = mainQuestionDto.HeadingQuestionId,
                TotalMarks = mainQuestionDto.TotalMarks,
                DisplayOrder = mainQuestionDto.DisplayOrder,
                Description = mainQuestionDto.Description,
            };

            _context.MainQuestions.Add(mainQuestion);
            _context.SaveChanges();
            return Ok(mainQuestion);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateMainQuestionDto mainQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MainQuestion? mainQuestion = _context.MainQuestions.Find(id);
            if (mainQuestion == null)
            {
                return BadRequest("Main Question Not Found");
            }

            if(mainQuestionDto.Title != null) mainQuestion.Title = mainQuestionDto.Title;
            if (mainQuestionDto.TotalMarks.HasValue) mainQuestion.TotalMarks = mainQuestionDto.TotalMarks.Value;
            if (mainQuestionDto.DisplayOrder.HasValue) mainQuestion.DisplayOrder = mainQuestionDto.DisplayOrder.Value;
            if (mainQuestionDto.Description != null) mainQuestion.Description = mainQuestionDto.Description;

            _context.SaveChanges();
            return Ok(mainQuestion);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            MainQuestion? mainQuestion = _context.MainQuestions.Find(id);
            if (mainQuestion == null)
            {
                return BadRequest("Main Question Not Found");
            }
            _context.MainQuestions.Remove(mainQuestion);
            _context.SaveChanges();
            return Ok(new { message = "Main Question deleted" });
        }
    }
}
