using ExamsApi.Models.Questions;
using ExamsApi.Models;
using ExamsApi.Models.Enums;
using ExamsApi.Services.Questions;
using ExamsApi.Services.Question.SingleChoice;
using ExamsApi.Services.Question.Paragraph;
namespace ExamsApi.Factories.Questions
{
    public class QuestionServiceFactory : IQuestionServiceFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public QuestionServiceFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IQuestionService GetService(QuestionType questionType)
        {
            return questionType switch
            {
                QuestionType.SingleChoice => _serviceProvider.GetRequiredService<SingleChoiceService>(),
                QuestionType.Paragraph => _serviceProvider.GetRequiredService<ParagraphService>(),
                _ => throw new NotSupportedException($"Question type {questionType} is not supported")
            };
        }
    }
}
