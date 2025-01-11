using ExamsApi.Data;
using ExamsApi.DTOs.MainQuestion;
using ExamsApi.DTOs.Question.SingleChoice;
using ExamsApi.Models;
using ExamsApi.Models.Questions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamsApi.Controllers.Questions
{
    [Route("api/[controller]")]
    [ApiController]
    public class SingleChoicesController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SingleChoicesController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Create(CreateSingleChoiceDto singleChoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            MainQuestion? mainQuestion = _context.MainQuestions.Find(singleChoiceDto.MainQuestionId);
            if (mainQuestion == null)
            {
                return BadRequest("Main Question Not Found");
            }
            SingleChoice question = new SingleChoice
            {
                MainQuestionId = mainQuestion.Id,
                Marks = singleChoiceDto.Marks,
                QuestionText = singleChoiceDto.QuestionText,
                Choice1 = singleChoiceDto.Choice1,
                Choice2 = singleChoiceDto.Choice2,
                Choice3 = singleChoiceDto.Choice3,
                Choice4 = singleChoiceDto.Choice4,
                Answer= singleChoiceDto.Answer,
            };

            _context.SingleChoiceQuestions.Add(question);
            _context.SaveChanges();
            return Ok(question);
        }

        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Update(int id, UpdateSingleChoiceDto singleChoiceDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            SingleChoice? question = _context.SingleChoiceQuestions.Find(id);
            if (question == null)
            {
                return BadRequest("Question Not Found");
            }

            if (singleChoiceDto.Marks.HasValue) question.Marks = singleChoiceDto.Marks.Value;
            if (singleChoiceDto.QuestionText != null) question.QuestionText = singleChoiceDto.QuestionText;
            if (singleChoiceDto.Choice1 != null) question.Choice1 = singleChoiceDto.Choice1;
            if (singleChoiceDto.Choice2 != null) question.Choice2 = singleChoiceDto.Choice2;
            if (singleChoiceDto.Choice3 != null) question.Choice3 = singleChoiceDto.Choice3;
            if (singleChoiceDto.Choice4 != null) question.Choice4 = singleChoiceDto.Choice4;
            if (singleChoiceDto.Answer != null) question.Answer = singleChoiceDto.Answer;

            _context.SaveChanges();
            return Ok(question);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            SingleChoice? question = _context.SingleChoiceQuestions.Find(id);
            if (question == null)
            {
                return BadRequest("Question Not Found");
            }
            _context.SingleChoiceQuestions.Remove(question);
            _context.SaveChanges();
            return Ok(new { message = "Question deleted" });
        }
    }
}
