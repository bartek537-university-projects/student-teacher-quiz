using QuizApp.Student.Presentation.QuizSession.Interfaces;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizSessionPresenter : IQuizSessionPresenter
{
    private readonly IQuizSessionView _view;

    public QuizSessionPresenter(IQuizSessionView view)
    {
        _view = view;
    }
}
