using ExamsApi.Models;
using ExamsApi.Models.Enums;
using ExamsApi.Services.Questions;

namespace ExamsApi.Factories.Questions
{
    public interface IQuestionServiceFactory
    {
        IQuestionService GetService(QuestionType questionType);
    }
}
