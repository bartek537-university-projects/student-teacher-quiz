using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizReviewPresenter : IQuizReviewPresenter
{
    private readonly IQuizReviewView _view;

    public IReadOnlyList<Question> Questions { get; }

    private readonly Dictionary<Guid, IReadOnlyList<Answer>> _userAnswers;
    private readonly Dictionary<Guid, int> _questionScores;

    public int CurrentQuestionIndex
    {
        get;
        set
        {
            field = Math.Clamp(value, 0, Math.Max(Questions.Count - 1, 0));
            CurrentQuestionChange?.Invoke();
        }
    } = 0;

    public Question? CurrentQuestionValue => Questions
        .ElementAtOrDefault(CurrentQuestionIndex);

    public IReadOnlyList<Answer> CurrentQuestionSelectedAnswers
    {
        get
        {
            if (CurrentQuestionValue is not { } question)
            {
                return [];
            }
            return _userAnswers.GetValueOrDefault(question.Guid, []);
        }
    }

    public int CurrentQuestionScore
    {
        get
        {
            if (CurrentQuestionValue is not { } question)
            {
                return 0;
            }
            return _questionScores.GetValueOrDefault(question.Guid, 0);
        }
    }

    public event Action? CurrentQuestionChange;

    public QuizReviewPresenter(IQuizReviewView view,
        IReadOnlyList<Question> questions,
        Dictionary<Guid, IReadOnlyList<Answer>> userAnswers,
        Dictionary<Guid, int> questionScores)
    {
        _view = view;

        Questions = questions;

        _userAnswers = userAnswers;
        _questionScores = questionScores;

        _view.Ready += OnViewReady;
        _view.NextQuestionClick += OnNextQuestionClicked;
        _view.PreviousQuestionClick += OnPreviousQuestionClicked;
    }

    private void OnViewReady()
    {
        CurrentQuestionChange?.Invoke();
    }

    private void OnNextQuestionClicked()
    {
        CurrentQuestionIndex += 1;
    }

    private void OnPreviousQuestionClicked()
    {
        CurrentQuestionIndex -= 1;
    }
}
