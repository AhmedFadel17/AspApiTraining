using AutoMapper;
using ExamsApi.DTOs.Exam;
using ExamsApi.DTOs.ExamModel;
using ExamsApi.DTOs.HeadingQuestion;
using ExamsApi.DTOs.MainQuestion;
using ExamsApi.DTOs.Question.Paragraph;
using ExamsApi.DTOs.Question.SingleChoice;
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
