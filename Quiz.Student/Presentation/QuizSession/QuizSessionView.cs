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

        tSessionTime.Tick += OnSessionTimeTick;
    }

    private void OnSessionTimeTick(object? sender, EventArgs e)
    {
        UpdateElapsedTime();
    }

    private void UpdateElapsedTime()
    {
        var time = Presenter.ElapsedTime.ToString(@"mm\:ss");
        lbSessionTime.Text = $"Time: {time}";
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
        UpdateElapsedTime();
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
        UpdateScore();
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

        QuizReviewView view = new();
        QuizReviewPresenter presenter = new(view, questions,
            Presenter.UserAnswers, Presenter.QuestionScores);
        view.Presenter = presenter;

        ReplaceMainComponent(view);
    }

    private void ReplaceMainComponent(Control control)
    {
        control.Dock = DockStyle.Fill;

        scMainLayout.Panel2.Controls.Clear();
        scMainLayout.Panel2.Controls.Add(control);
    }

    private void UpdateScore()
    {
        var scores = Presenter.QuestionScores;

        var collectedPoints = scores.Sum(s => s.Value);
        var possiblePoints = Presenter.Quiz.Questions.Sum(q => q.PlusPoints);

        var accuracy = scores.Count(s => s.Value > 0) / (double)scores.Count;

        lbScorePoints.Text = $"Score: {collectedPoints} / {possiblePoints}";
        lbScoreAccuracy.Text = $"Accuracy: {accuracy:P0}";
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
