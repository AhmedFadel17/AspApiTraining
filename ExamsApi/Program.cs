using ExamsApi.Data;
using ExamsApi.Factories.Questions;
using ExamsApi.Filters;
using ExamsApi.Middlewares;
using ExamsApi.Services.Exam;
using ExamsApi.Services.ExamModel;
using ExamsApi.Services.HeadingQuestion;
using ExamsApi.Services.MainQuestion;
using ExamsApi.Services.Question.Paragraph;
using ExamsApi.Services.Question.SingleChoice;
using ExamsApi.Services.Questions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IExamService, ExamService>();
builder.Services.AddScoped<IExamModelService, ExamModelService>();
builder.Services.AddScoped<IHeadingQuestionService, HeadingQuestionService>();
builder.Services.AddScoped<IMainQuestionService, MainQuestionService>();
builder.Services.AddScoped<IQuestionService, SingleChoiceService>();
builder.Services.AddScoped<IQuestionService, ParagraphService>();
builder.Services.AddScoped<IQuestionServiceFactory, QuestionServiceFactory>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.SuppressModelStateInvalidFilter = true;
});
builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidationFilter>();
});
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.MapControllers();

app.Run();
