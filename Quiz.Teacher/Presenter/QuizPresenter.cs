using QuizApp.Core.Domain;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presenter;

internal class QuizPresenter
{
    private const string DEFAULT_QUIZ_TITLE = "Nowy Quiz";

    private readonly IQuizView _quizView;

    private Quiz Quiz
    {
        get => _quizView.Quiz;
        set => _quizView.Quiz = value;
    }

    public QuizPresenter(
        IQuizView quizView
        )
    {
        _quizView = quizView;

        _quizView.OnQuizTitleChange += QuizTitleChange;
        _quizView.OnClear += QuizClear;
    }

    private void QuizTitleChange(string title)
    {
        Quiz = Quiz with { Title = title };
    }

    private void QuizClear()
    {
        Quiz = new Quiz(DEFAULT_QUIZ_TITLE, []);
    }
}
