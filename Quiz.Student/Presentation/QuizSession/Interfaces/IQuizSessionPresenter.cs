using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Values;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizSessionPresenter
{
    QuizSessionState State { get; set; }

    Quiz Quiz { get; }
    Dictionary<Guid, IReadOnlyList<Answer>> UserAnswers { get; }
    Dictionary<Guid, int> QuestionScores { get; }

    TimeSpan ElapsedTime { get; }

    event Action StateChange;
}
