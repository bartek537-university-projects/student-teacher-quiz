using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;
using QuizApp.Student.Presentation.QuizSession.Values;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizSessionPresenter : IQuizSessionPresenter
{
    private readonly IQuizSessionView _view;
    private readonly Quiz _quiz;

    public QuizSessionState State
    {
        get;
        set
        {
            if (field == value)
            {
                return;
            }

            field = value;
            StateChange?.Invoke();
        }
    } = QuizSessionState.Initialized;

    public event Action? StateChange;

    public QuizSessionPresenter(IQuizSessionView view, Quiz quiz)
    {
        _view = view;
        _quiz = quiz;

        _view.Ready += OnViewReady;
        _view.StartClick += OnStartClicked;
        _view.StopClick += OnStopClicked;
    }

    private void OnViewReady()
    {
        _view.Title = _quiz.Title;
        StateChange?.Invoke();
    }

    private void OnStartClicked()
    {
        State = QuizSessionState.Started;
    }

    private void OnStopClicked()
    {
        State = QuizSessionState.Finished;
    }
}
