﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ExamsApi.Application.DTOs.Questions.Paragraph;
using ExamsApi.Application.Interfaces.Questions;
using ExamsApi.Application.Services.Questions;

namespace ExamsApi.WebUi.Controllers.Questions
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ParagraphsController : ControllerBase
    {
        private readonly IQuestionService _paragraphService;

        public ParagraphsController(ParagraphService paragraphService)
        {
            _paragraphService = paragraphService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(CreateParagraphDto paragraphDto)
        {
            var question = await _paragraphService.CreateQuestionAsync(paragraphDto);
            return Ok(question);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UpdateParagraphDto paragraphDto)
        {
            var question = await _paragraphService.UpdateQuestionAsync(id, paragraphDto);
            return Ok(question);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var isDeleted = await _paragraphService.DeleteQuestionAsync(id);
            return Ok(new { message = "Question deleted" });
        }
    }
}
