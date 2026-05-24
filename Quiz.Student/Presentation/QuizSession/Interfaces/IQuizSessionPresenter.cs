using QuizApp.Student.Presentation.QuizSession.Values;

namespace QuizApp.Student.Presentation.QuizSession.Interfaces;

internal interface IQuizSessionPresenter
{
    QuizSessionState State { get; set; }
    TimeSpan ElapsedTime { get; }

    event Action StateChange;
}
