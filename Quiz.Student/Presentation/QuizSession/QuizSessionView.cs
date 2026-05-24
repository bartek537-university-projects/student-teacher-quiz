using QuizApp.Core.Domain;
using QuizApp.Student.Presentation.QuizSession.Interfaces;
using System.Collections.Immutable;
using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSession;

internal partial class QuizSessionView : Form, IQuizSessionView
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IQuizSessionPresenter Presenter
    {
        private get;
        set
        {
            field = value;
            SetupPresenter();
        }
    } = null!;

    public Dictionary<Guid, IReadOnlyList<Answer>> UserAnswers { get; private set; } = [];

    public event Action? Ready;
    public event Action? StartClick;
    public event Action? StopClick;
    public event Action? UserAnswersChange;

    public QuizSessionView()
    {
        InitializeComponent();

        tSessionTime.Tick += UpdateElapsedTime;
    }

    private void UpdateElapsedTime(object? sender, EventArgs e)
    {
        lbSessionTime.Text = Presenter.ElapsedTime.ToString(@"mm\:ss");
    }

    private void SetupPresenter()
    {
        Presenter?.StateChange += OnStateChanged;
    }

    private void OnStateChanged()
    {
        switch (Presenter.State)
        {
            case Values.QuizSessionState.Initialized:
                InitializeQuiz();
                break;
            case Values.QuizSessionState.Started:
                StartQuiz();
                break;
            case Values.QuizSessionState.Finished:
                FinishQuiz();
                break;
        }
    }

    private void InitializeQuiz()
    {
        btnStartQuiz.Enabled = true;
        btnFinishQuiz.Enabled = false;
        Text = Presenter.Quiz.Title;
        DisplayQuizTitleScreen();
    }

    private void StartQuiz()
    {
        tSessionTime.Start();
        btnStartQuiz.Enabled = false;
        btnFinishQuiz.Enabled = true;
        DisplayQuizQuestionScreen();
    }

    private void FinishQuiz()
    {
        tSessionTime.Stop();
        btnStartQuiz.Enabled = false;
        btnFinishQuiz.Enabled = false;
        DisplayQuizReviewScreen();
    }

    private void DisplayQuizTitleScreen()
    {
        Quiz quiz = Presenter.Quiz;

        QuizTitleView view = new()
        {
            Parent = this,
            QuizId = quiz.Guid.ToString(),
            Title = quiz.Title,
        };

        ReplaceMainComponent(view);
    }

    private void DisplayQuizQuestionScreen()
    {
        ImmutableArray<Question> questions = Presenter.Quiz.Questions;

        QuizQuestionView view = new();
        QuizQuestionPresenter presenter = new(view, questions);
        view.Presenter = presenter;

        presenter.UserAnswersChanged += () =>
        {
            UserAnswers = presenter.UserAnswers;
            UserAnswersChange?.Invoke();
        };

        ReplaceMainComponent(view);
    }

    private void DisplayQuizReviewScreen()
    {
        ImmutableArray<Question> questions = Presenter.Quiz.Questions;
        Dictionary<Guid, IReadOnlyList<Answer>> userAnswers = Presenter.UserAnswers;

        QuizReviewView view = new();
        QuizReviewPresenter presenter = new(view, questions, userAnswers);
        view.Presenter = presenter;

        ReplaceMainComponent(view);
    }

    private void ReplaceMainComponent(Control control)
    {
        control.Dock = DockStyle.Fill;

        scMainLayout.Panel2.Controls.Clear();
        scMainLayout.Panel2.Controls.Add(control);
    }

    private void QuizSessionView_Load(object sender, EventArgs e)
    {
        Ready?.Invoke();
    }

    private void btnStartQuiz_Click(object sender, EventArgs e)
    {
        StartClick?.Invoke();
    }

    private void btnFinishQuiz_Click(object sender, EventArgs e)
    {
        DialogResult confirmation = MessageBox.Show(
            "Do you want to finish this attempt? Once you do, you won't be able to change your answers.",
            "Finish quiz", MessageBoxButtons.OKCancel);

        if (confirmation != DialogResult.OK)
        {
            return;
        }

        StopClick?.Invoke();
    }
}
