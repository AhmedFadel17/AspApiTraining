﻿using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.HeadingQuestions
{
    public record CreateHeadingQuestionDto
    {
        [Required, MaxLength(255)]
        public required string Title { get; set; }
        [Required]
        public int ExamModelId { get; set; }
        [Required, Range(0, 1000)]
        public double TotalMarks { get; set; }
        [Required, Range(0, 1000)]
        public int DisplayOrder { get; set; }
    }
}
