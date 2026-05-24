using QuizApp.Student.Presentation.QuizSession.Interfaces;
using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSession;

internal partial class QuizReviewView : UserControl, IQuizReviewView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IQuizReviewPresenter Presenter
    {
        private get;
        set
        {
            field = value;
            SetupPresenter();
        }
    } = null!;

    public event Action? Ready;
    public event Action? NextQuestionClick;
    public event Action? PreviousQuestionClick;

    public QuizReviewView()
    {
        InitializeComponent();

        alAnswers.Marked = true;
        pcControls.NextClick += OnNextQuestionClicked;
        pcControls.PreviousClick += OnPreviousQuestionClicked;
    }

    private void QuizReviewView_Load(object sender, EventArgs e)
    {
        Ready?.Invoke();
    }

    private void OnNextQuestionClicked()
    {
        NextQuestionClick?.Invoke();
    }

    private void OnPreviousQuestionClicked()
    {
        PreviousQuestionClick?.Invoke();
    }

    private void SetupPresenter()
    {
        Presenter.CurrentQuestionChange += OnCurrentQuestionChanged;
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
            lbPoints.Text = GetPointsText(0);
            lbTitle.Text = "";
            alAnswers.Answers = [];
            alAnswers.SelectedAnswers = [];
            return;
        }

        lbPoints.Text = GetPointsText(Presenter.CurrentQuestionScore);
        lbTitle.Text = question.Title;
        alAnswers.Answers = question.Answers;
        alAnswers.SelectedAnswers = Presenter.CurrentQuestionSelectedAnswers;
    }

    private string GetPointsText(int points)
    {
        return $"{points} pts";
    }
}
