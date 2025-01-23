using ExamsApi.Domain;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using ExamsApi.DataAccess.Data;
using ExamsApi.DataAccess.Repositories.Exams;
using ExamsApi.DataAccess.Repositories.ExamModels;
using ExamsApi.DataAccess.Repositories.HeadingQuestions;
using ExamsApi.DataAccess.Repositories.MainQuestions;
using ExamsApi.DataAccess.Repositories.Questions;
using ExamsApi.DataAccess.Repositories.Auth;
namespace ExamsApi.DataAccess
{
    public static class Startup
    {
        public static Task<IServiceCollection> AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamModelRepository, ExamModelRepository>();
            services.AddScoped<IHeadingQuestionRepository, HeadingQuestionRepository>();
            services.AddScoped<IMainQuestionRepository, MainQuestionRepository>();
            services.AddScoped<IQuestionRepository, SingleChoiceRepository>();
            services.AddScoped<IQuestionRepository, ParagraphRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            return Task.FromResult(services);
        }
    }
}
