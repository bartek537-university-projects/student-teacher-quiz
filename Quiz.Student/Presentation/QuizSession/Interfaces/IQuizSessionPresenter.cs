using QuizApp.Student.Presentation.QuizSession.Values;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizSessionPresenter
{
    QuizSessionState State { get; set; }

    event Action StateChange;
}
