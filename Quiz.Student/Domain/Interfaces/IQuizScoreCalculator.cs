using QuizApp.Core.Domain;

namespace QuizApp.Student.Domain.Interfaces;

internal interface IQuizScoreCalculator
{
    Dictionary<Guid, int> Score(
        IReadOnlyList<Question> questions,
        IReadOnlyDictionary<Guid, IReadOnlyList<Answer>> userAnswers);
}
