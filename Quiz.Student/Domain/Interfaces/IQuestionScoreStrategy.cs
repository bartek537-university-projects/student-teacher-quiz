using QuizApp.Core.Domain;

namespace QuizApp.Student.Domain.Interfaces;

internal interface IQuestionScoreStrategy
{
    int Score(Question question, IReadOnlyList<Answer> userAnswer);
}
