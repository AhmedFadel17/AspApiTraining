﻿using ExamsApi.Domain.Enums;
using ExamsApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.Questions.Paragraph
{
    public record CreateParagraphDto : ICreateQuestionDto
    {
        [Required]
        public int MainQuestionId { get; set; }
        [Required, Range(0, 1000)]
        public double Marks { get; set; }
        [Required, Range(0, 1000)]
        public int DisplayOrder { get; set; }
        [Required, Range(0, 5000)]
        public int MinWords { get; set; }
        [Required, MaxLength(255)]
        public required string Title { get; set; }
        [Required, MaxLength(255)]
        public string? GuidingWords { get; set; }
    }
}
