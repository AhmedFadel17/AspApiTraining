using ExamsApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ExamsApi.DTOs.Questions
{
    public interface ICreateQuestionDto
    {
        public int MainQuestionId { get; set; }
        public double Marks { get; set; }
        public int DisplayOrder { get; set; }
    }
}
