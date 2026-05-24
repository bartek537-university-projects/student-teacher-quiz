using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizQuestionPresenter : IQuizQuestionPresenter
{
    private readonly IQuizQuestionView _view;
    public Dictionary<Guid, IReadOnlyList<Answer>> UserAnswers { get; private set; } = [];

    public IReadOnlyList<Question> Questions { get; }

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
            return UserAnswers.GetValueOrDefault(question.Guid, []);
        }
    }

    public event Action? CurrentQuestionChange;
    public event Action? UserAnswersChanged;

    public QuizQuestionPresenter(IQuizQuestionView view, IReadOnlyList<Question> questions)
    {
        _view = view;

        Questions = questions;

        _view.Ready += OnViewReady;
        _view.AnswerSelectionChange += OnAnswerSelectionChanged;
        _view.NextQuestionClick += OnNextQuestionClicked;
        _view.PreviousQuestionClick += OnPreviousQuestionClicked;
    }

    private void OnViewReady()
    {
        CurrentQuestionChange?.Invoke();
    }

    private void OnAnswerSelectionChanged(IReadOnlyList<Answer> answers)
    {
        if (CurrentQuestionValue is not { } question)
        {
            return;
        }
        UserAnswers[question.Guid] = answers;
        UserAnswersChanged?.Invoke();
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
