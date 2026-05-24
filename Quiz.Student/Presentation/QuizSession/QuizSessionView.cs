using QuizApp.Student.Presentation.QuizSession.Interfaces;
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

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public string Title { set => Text = value; }

    public event Action? Ready;
    public event Action? StartClick;
    public event Action? StopClick;

    public QuizSessionView()
    {
        InitializeComponent();

        tSessionTime.Tick += UpdateElapsedTime;

        // TODO: Move this to appropriate layers.
        QuizQuestionView view = new()
        {
            Dock = DockStyle.Fill
        };

        QuizQuestionPresenter presenter = new(view);
        view.Presenter = presenter;
        presenter.Questions = [
            new Core.Domain.Question() {
                Title = "Ile nóg ma hulajnoga?",
                PlusPoints = 2,
                MinusPoints = 0,
                Answers = [
                    new Core.Domain.Answer() { Title = "Jedną", IsCorrect = true },
                    new Core.Domain.Answer() { Title = "Dwie", IsCorrect = false },
                    new Core.Domain.Answer() { Title = "Czterdzieści dwie", IsCorrect = true },
                    new Core.Domain.Answer() { Title = "Sto", IsCorrect = false },
                ]
            },
            new Core.Domain.Question() {
                Title = "Ile rąk ma stonoga?",
                PlusPoints = 2,
                MinusPoints = 4,
                Answers = [
                    new Core.Domain.Answer() { Title = "Jedną", IsCorrect = false },
                    new Core.Domain.Answer() { Title = "Dwie", IsCorrect = false },
                    new Core.Domain.Answer() { Title = "Czterdzieści dwie", IsCorrect = true },
                    new Core.Domain.Answer() { Title = "Sto", IsCorrect = false },
                ]
            }
        ];

        scMainLayout.Panel2.Controls.Clear();
        scMainLayout.Panel2.Controls.Add(view);
    }

    private void UpdateElapsedTime(object? sender, EventArgs e)
    {
        lbSessionTime.Text = Presenter.ElapsedTime.ToString(@"mm\:ss\.fff");
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
    }

    private void StartQuiz()
    {
        tSessionTime.Start();
        btnStartQuiz.Enabled = false;
        btnFinishQuiz.Enabled = true;
    }

    private void FinishQuiz()
    {
        tSessionTime.Stop();
        btnStartQuiz.Enabled = false;
        btnFinishQuiz.Enabled = false;
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
        StopClick?.Invoke();
    }
}
