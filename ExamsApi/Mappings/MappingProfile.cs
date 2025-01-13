using AutoMapper;
using ExamsApi.DTOs.Exams;
using ExamsApi.DTOs.ExamModels;
using ExamsApi.DTOs.HeadingQuestions;
using ExamsApi.DTOs.MainQuestions;
using ExamsApi.DTOs.Questions.Paragraph;
using ExamsApi.DTOs.Questions.SingleChoice;
using ExamsApi.Models;
using ExamsApi.Models.Questions;

namespace ExamsApi.Mappings
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
