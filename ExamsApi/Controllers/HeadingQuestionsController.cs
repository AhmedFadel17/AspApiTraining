using ExamsApi.Data;
using ExamsApi.DTOs.ExamModel;
using ExamsApi.DTOs.HeadingQuestion;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeadingQuestionsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public HeadingQuestionsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(CreateHeadingQuestionDto headingQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            ExamModel? examModel = _context.ExamModels.Find(headingQuestionDto.ExamModelId);
            if (examModel == null)
            {
                return BadRequest("Exam Model Not Found");
            }
            HeadingQuestion headingQuestion = new HeadingQuestion
            {
                Title = headingQuestionDto.Title,
                ExamModelId = examModel.Id,
                TotalMarks=headingQuestionDto.TotalMarks,
                DisplayOrder=headingQuestionDto.DisplayOrder,
            };
   
            _context.HeadingQuestions.Add(headingQuestion);
            _context.SaveChanges();
            return Ok(headingQuestion);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateHeadingQuestionDto headingQuestionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HeadingQuestion? headingQuestion = _context.HeadingQuestions.Find(id);
            if (headingQuestion == null)
            {
                return BadRequest("Heading Question Not Found");
            }

            if(headingQuestionDto.Title != null) headingQuestion.Title = headingQuestionDto.Title;
            if (headingQuestionDto.TotalMarks.HasValue) headingQuestion.TotalMarks = headingQuestionDto.TotalMarks.Value;
            if (headingQuestionDto.DisplayOrder.HasValue) headingQuestion.DisplayOrder = headingQuestionDto.DisplayOrder.Value;

            _context.SaveChanges();
            return Ok(headingQuestion);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            HeadingQuestion? headingQuestion = _context.HeadingQuestions.Find(id);
            if (headingQuestion == null)
            {
                return BadRequest("Heading Question Not Found");
            }
            _context.HeadingQuestions.Remove(headingQuestion);
            _context.SaveChanges();
            return Ok(new { message = "Heading Question deleted" });
        }
    }
}
