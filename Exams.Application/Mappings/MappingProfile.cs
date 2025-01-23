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
            CreateMap<UpdateExamDto, Exam>()
                .ForAllMembers(field => field.Condition((from, to, fromMember) => fromMember != null));

            CreateMap<ExamModel, ExamModelResponseDto>();
            CreateMap<CreateExamModelDto, ExamModel>();
            CreateMap<UpdateExamModelDto, ExamModel>()
                .ForAllMembers(field => field.Condition((from, to, fromMember) => fromMember != null));

            CreateMap<HeadingQuestion, HeadingQuestionResponseDto>();
            CreateMap<CreateHeadingQuestionDto, HeadingQuestion>();
            CreateMap<UpdateHeadingQuestionDto, HeadingQuestion>()
                .ForAllMembers(field => field.Condition((from, to, fromMember) => fromMember != null));

            CreateMap<MainQuestion, MainQuestionResponseDto>();
            CreateMap<CreateMainQuestionDto, MainQuestion>();
            CreateMap<UpdateMainQuestionDto, MainQuestion>()
                .ForAllMembers(field => field.Condition((from, to, fromMember) => fromMember != null));

            CreateMap<Paragraph, ParagraphResponseDto>();
            CreateMap<CreateParagraphDto, Paragraph>();
            CreateMap<UpdateParagraphDto, Paragraph>()
                .ForAllMembers(field => field.Condition((from, to, fromMember) => fromMember != null));

            CreateMap<SingleChoice, SingleChoiceResponseDto>();
            CreateMap<CreateSingleChoiceDto, SingleChoice>();
            CreateMap<UpdateSingleChoiceDto, SingleChoice>()
                .ForAllMembers(field => field.Condition((from, to, fromMember) => fromMember != null));
        }
        
    }
}
