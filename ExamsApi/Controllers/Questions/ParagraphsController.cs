using ExamsApi.DTOs.Question.SingleChoice;
using ExamsApi.Models.Questions;
using ExamsApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ExamsApi.Data;
using ExamsApi.DTOs.Question.Paragraph;

namespace ExamsApi.Controllers.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParagraphsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ParagraphsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(CreateParagraphDto paragraphDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MainQuestion? mainQuestion = _context.MainQuestions.Find(paragraphDto.MainQuestionId);
            if (mainQuestion == null)
            {
                return BadRequest("Main Question Not Found");
            }
            Paragraph question = new Paragraph
            {
                MainQuestionId = mainQuestion.Id,
                Marks = paragraphDto.Marks,
                MinWords = paragraphDto.MinWords,
                Title = paragraphDto.Title,
                GuidingWords = paragraphDto.GuidingWords ?? "",
            };

            _context.ParagraphQuestions.Add(question);
            _context.SaveChanges();
            return Ok(question);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateParagraphDto paragraphDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Paragraph? question = _context.ParagraphQuestions.Find(id);
            if (question == null)
            {
                return BadRequest("Question Not Found");
            }

            if (paragraphDto.Marks.HasValue) question.Marks = paragraphDto.Marks.Value;
            if (paragraphDto.MinWords.HasValue) question.MinWords = paragraphDto.MinWords.Value;
            if (paragraphDto.Title != null) question.Title = paragraphDto.Title;
            if (paragraphDto.GuidingWords != null) question.GuidingWords = paragraphDto.GuidingWords;

            _context.SaveChanges();
            return Ok(question);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            Paragraph? question = _context.ParagraphQuestions.Find(id);
            if (question == null)
            {
                return BadRequest("Question Not Found");
            }
            _context.ParagraphQuestions.Remove(question);
            _context.SaveChanges();
            return Ok(new { message = "Question deleted" });
        }
    }
}
