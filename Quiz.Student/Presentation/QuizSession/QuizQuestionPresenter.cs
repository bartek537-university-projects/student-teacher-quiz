using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;

namespace QuizApp.Student.Presentation.QuizSession;

internal class QuizQuestionPresenter : IQuizQuestionPresenter
{
    private readonly IQuizQuestionView _view;
    private readonly Dictionary<Guid, IReadOnlyList<Answer>> _answers = [];

    public IReadOnlyList<Question> Questions
    {
        get;
        set
        {
            field = value;
            CurrentQuestionIndex = 0;
        }
    } = [];

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

    public IReadOnlyList<Answer> CurrentQuestionAnswers
    {
        get
        {
            if (CurrentQuestionValue is not { } question)
            {
                return [];
            }
            return _answers.GetValueOrDefault(question.Guid, []);
        }
    }

    public event Action? CurrentQuestionChange;

    public QuizQuestionPresenter(IQuizQuestionView view)
    {
        _view = view;

        _view.Ready += OnViewReady;
        _view.AnswerSelectionChange += OnAnswerSelectionChanged;
    }

    private void OnViewReady()
    {
        // TODO:
    }

    private void OnAnswerSelectionChanged(IReadOnlyList<Answer> answers)
    {
        if (CurrentQuestionValue is not { } question)
        {
            return;
        }
        _answers[question.Guid] = answers;
    }
}
