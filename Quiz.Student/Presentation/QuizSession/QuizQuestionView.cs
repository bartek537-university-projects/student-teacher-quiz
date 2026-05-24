using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;
using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSession;

internal partial class QuizQuestionView : UserControl, IQuizQuestionView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IQuizQuestionPresenter Presenter
    {
        private get;
        set
        {
            field = value;
            SetupPresenter();
        }
    } = null!;

    public event Action? Ready;
    public event Action<IReadOnlyList<Answer>>? AnswerSelectionChange;

    public QuizQuestionView()
    {
        InitializeComponent();

        alAnswers.SelectedAnswersChanged += OnSelectedAnswersChanged;
        pcControls.NextClick += OnNextQuestionClicked;
        pcControls.PreviousClick += OnPreviousQuestionClicked;
    }

    private void OnSelectedAnswersChanged()
    {
        var answers = alAnswers.SelectedAnswers;
        AnswerSelectionChange?.Invoke(answers);
    }

    private void OnNextQuestionClicked()
    {
        Presenter.CurrentQuestionIndex += 1;
    }

    private void OnPreviousQuestionClicked()
    {
        Presenter.CurrentQuestionIndex -= 1;
    }

    private void SetupPresenter()
    {
        Presenter.CurrentQuestionChange += OnCurrentQuestionChanged;
        OnCurrentQuestionChanged();
    }

    private void OnCurrentQuestionChanged()
    {
        UpdateControls();
        UpdateQuestion();
    }

    private void UpdateControls()
    {
        pcControls.PageCount = Presenter.Questions.Count;
        pcControls.CurrentPage = Presenter.CurrentQuestionIndex + 1;
    }

    private void UpdateQuestion()
    {
        if (Presenter.CurrentQuestionValue is not { } question)
        {
            lbPoints.Text = GetPointsText(0, 0);
            lbTitle.Text = "";
            alAnswers.Answers = [];
            alAnswers.SelectedAnswers = [];
            return;
        }

        lbPoints.Text = GetPointsText(question.PlusPoints, question.MinusPoints);
        lbTitle.Text = question.Title;
        alAnswers.Answers = question.Answers;
        alAnswers.SelectedAnswers = Presenter.CurrentQuestionAnswers;
    }

    private static string GetPointsText(int plus, int minus)
    {
        string score = (plus, minus) switch
        {
            ( > 0, > 0) => $"{plus}/-{minus}",
            ( > 0, _) => $"{plus}",
            (_, > 0) => $"-{minus}",
            _ => "0"
        };

        return $"({score} pts)";
    }

    private void QuizQuestionView_Load(object sender, EventArgs e)
    {
        Ready?.Invoke();
    }
}
