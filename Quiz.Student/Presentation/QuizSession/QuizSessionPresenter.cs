using QuizApp.Core.Domain;
using QuizApp.Student.Domain.Interfaces;
using QuizApp.Student.Presentation.QuizSession.Interfaces;
using QuizApp.Student.Presentation.QuizSession.Values;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizSessionPresenter : IQuizSessionPresenter
{
    private readonly IQuizSessionView _view;
    private readonly TimeProvider _timeProvider;
    private readonly IQuizScoreCalculator _scoreCalculator;

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

    public Quiz Quiz { get; }
    public Dictionary<Guid, IReadOnlyList<Answer>> UserAnswers { get; private set; } = [];
    public Dictionary<Guid, int> QuestionScores { get; private set; } = [];

    public event Action? StateChange;

    public QuizSessionPresenter(IQuizSessionView view,
        TimeProvider timeProvider,
        IQuizScoreCalculator scoreCalculator,
        Quiz quiz)
    {
        _view = view;
        _timeProvider = timeProvider;
        _scoreCalculator = scoreCalculator;

        Quiz = quiz;

        _view.Ready += OnViewReady;
        _view.StartClick += OnStartClicked;
        _view.StopClick += OnStopClicked;
        _view.UserAnswersChange += OnUserAnswersChanged;
    }

    private void OnViewReady()
    {
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

        QuestionScores = _scoreCalculator.Score(Quiz.Questions, UserAnswers);
        State = QuizSessionState.Finished;
    }

    private void OnUserAnswersChanged()
    {
        UserAnswers = _view.UserAnswers;
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
