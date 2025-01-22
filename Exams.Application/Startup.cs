using ExamsApi.Application.Interfaces.Auth;
using ExamsApi.Application.Interfaces.ExamModels;
using ExamsApi.Application.Interfaces.Exams;
using ExamsApi.Application.Interfaces.Hashers;
using ExamsApi.Application.Interfaces.HeadingQuestions;
using ExamsApi.Application.Interfaces.MainQuestions;
using ExamsApi.Application.Interfaces.Questions;
using ExamsApi.Application.Services.Auth;
using ExamsApi.Application.Services.ExamModels;
using ExamsApi.Application.Services.Exams;
using ExamsApi.Application.Services.Hashers;
using ExamsApi.Application.Services.HeadingQuestions;
using ExamsApi.Application.Services.MainQuestions;
using ExamsApi.Application.Services.Questions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ExamsApi.DataAccess;
namespace ExamsApi.Application
{
    public static class ApplicationServicesConfiguration
    {
        public static Task<IServiceCollection> AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExamService, ExamService>();
            services.AddScoped<IExamModelService, ExamModelService>();
            services.AddScoped<IHeadingQuestionService, HeadingQuestionService>();
            services.AddScoped<IMainQuestionService, MainQuestionService>();
            services.AddScoped<IQuestionService, SingleChoiceService>();
            services.AddScoped<IQuestionService, ParagraphService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            return Task.FromResult(services);
        }
    }
}
