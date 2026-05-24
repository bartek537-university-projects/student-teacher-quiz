using QuizApp.Core.Domain;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizSessionView
{
    Dictionary<Guid, IReadOnlyList<Answer>> UserAnswers { get; }

    event Action Ready;
    event Action StartClick;
    event Action StopClick;
    event Action UserAnswersChange;
}
