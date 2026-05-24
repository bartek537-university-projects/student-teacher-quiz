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
    }

    private void SetupPresenter()
    {
        Presenter?.StateChange += OnStateChanged;
    }

    private void OnStateChanged()
    {
        btnStartQuiz.Enabled = Presenter.State == Values.QuizSessionState.Initialized;
        btnFinishQuiz.Enabled = Presenter.State == Values.QuizSessionState.Started;
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
