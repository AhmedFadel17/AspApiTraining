﻿using ExamsApi.Domain.Enums;
using ExamsApi.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.Application.DTOs.Questions.SingleChoice
{
    public record UpdateSingleChoiceDto : IUpdateQuestionDto
    {
        [Range(0, 1000)]
        public double? Marks { get; set; }
        [Range(0, 1000)]
        public int? DisplayOrder { get; set; }
        [MaxLength(455)]
        public string? QuestionText { get; set; }
        [MaxLength(255)]
        public string? Choice1 { get; set; }
        [MaxLength(255)]
        public string? Choice2 { get; set; }
        [MaxLength(255)]
        public string? Choice3 { get; set; }
        [MaxLength(255)]
        public string? Choice4 { get; set; }
        [MaxLength(255)]
        public string? Answer { get; set; }
    }
}
