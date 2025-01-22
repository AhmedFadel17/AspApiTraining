using AutoMapper;
using ExamsApi.Application.DTOs.Exams;
using ExamsApi.Application.DTOs.ExamModels;
using ExamsApi.Application.DTOs.HeadingQuestions;
using ExamsApi.Application.DTOs.MainQuestions;
using ExamsApi.Application.DTOs.Questions.Paragraph;
using ExamsApi.Application.DTOs.Questions.SingleChoice;
using ExamsApi.Domain.Models;
using ExamsApi.Domain.Models.Questions;

namespace ExamsApi.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Exam, ExamResponseDto>();
            CreateMap<CreateExamDto, Exam>();
            CreateMap<UpdateExamDto, Exam>();

            CreateMap<ExamModel, ExamModelResponseDto>();
            CreateMap<CreateExamModelDto, ExamModel>();
            CreateMap<UpdateExamModelDto, ExamModel>();

            CreateMap<HeadingQuestion, HeadingQuestionResponseDto>();
            CreateMap<CreateHeadingQuestionDto, HeadingQuestion>();
            CreateMap<UpdateHeadingQuestionDto, HeadingQuestion>();

            CreateMap<MainQuestion, MainQuestionResponseDto>();
            CreateMap<CreateMainQuestionDto, MainQuestion>();
            CreateMap<UpdateMainQuestionDto, MainQuestion>();

            CreateMap<Paragraph, ParagraphResponseDto>();
            CreateMap<CreateParagraphDto, Paragraph>();
            CreateMap<UpdateParagraphDto, Paragraph>();

            CreateMap<SingleChoice, SingleChoiceResponseDto>();
            CreateMap<CreateSingleChoiceDto, SingleChoice>();
            CreateMap<UpdateSingleChoiceDto, SingleChoice>();
        }
        
    }
}
