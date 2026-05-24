using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;
using QuizApp.Student.Presentation.QuizSession.Values;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizSessionPresenter : IQuizSessionPresenter
{
    private readonly IQuizSessionView _view;
    private readonly TimeProvider _timeProvider;
    private readonly Quiz _quiz;

    private DateTime? _timeStarted;
    private DateTime? _timeFinished;

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

    public TimeSpan ElapsedTime => GetElapsedTime();

    public event Action? StateChange;

    public QuizSessionPresenter(IQuizSessionView view,
        TimeProvider timeProvider,
        Quiz quiz)
    {
        _view = view;
        _timeProvider = timeProvider;
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
        StartQuiz();
    }

    private void StartQuiz()
    {
        if (State != QuizSessionState.Initialized)
        {
            return;
        }

        _timeStarted = GetCurrentDateTime();
        State = QuizSessionState.Started;
    }

    private void OnStopClicked()
    {
        FinishQuiz();
    }

    private void FinishQuiz()
    {
        if (State != QuizSessionState.Started)
        {
            return;
        }

        _timeFinished = GetCurrentDateTime();
        State = QuizSessionState.Finished;
    }

    private TimeSpan GetElapsedTime()
    {
        if (_timeStarted is not { } start)
        {
            return TimeSpan.Zero;
        }
        DateTime end = _timeFinished
            ?? GetCurrentDateTime();

        return end - start;
    }

    private DateTime GetCurrentDateTime()
    {
        return _timeProvider.GetUtcNow().DateTime;
    }
}
