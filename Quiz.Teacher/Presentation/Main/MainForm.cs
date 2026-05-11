using QuizApp.Core.Domain;
using QuizApp.Teacher.Presentation.WinHelpers;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class MainForm : Form, IEditorView
{
    public string Title
    {
        get => tbxTitle.Text;
        set => tbxTitle.Text = lbAutoTitle.Text = value;
    }

    public Quiz Quiz
    {
        get;
        set
        {
            if ((field = value) != null)
            {
                RefreshView();
            }
        }
    }

    public int Lock
    {
        get;
        set
        {
            bool locked = (field = value) > 0;

            pnLock.Visible = locked;

            if (locked)
            {
                pnLock.BringToFront();
                ActiveControl = pnLock;
            }
        }
    }

    public event Action<string>? OnTitleChange;

    public event Action? OnClearRequest;
    public event Action? OnClearInstant;

    public event Action? OnLoadRequest;
    public event Action? OnSaveRequest;

    private readonly QuestionView _questionView;
    private readonly AnswerView _answerView;

    public MainForm(
        out IEditorView editorView,
        out IQuestionView questionView,
        out IAnswerView answerView
        )
    {
        InitializeComponent();

        Quiz = null!; // presenter will overwrite it
        Lock = 0;

        editorView = this;
        questionView = _questionView = new QuestionView(this, pnQuestions);
        answerView = _answerView = new AnswerView(this, _questionView.PanelIndexer);
    }

    private void MainForm_Load(object sender, EventArgs e)
    {
        OnClearInstant?.Invoke();
    }

    private void RefreshView()
    {
        List<Panel> panels = _questionView.AllPanels();
        panels.ForEach(p => p.SuspendLayout());
        try
        {
            Title = Quiz.Title;

            _questionView.RefreshView();
            _answerView.RefreshView();
        }
        finally
        {
            panels.ForEach(p => p.ResumeLayout(true));
        }
    }

    public void ShowValidationProblems(string message, int? questionIndex)
    {
        if (questionIndex.HasValue)
        {
            _questionView.HighlightError(questionIndex.Value);
        }

        ShowError(message);
    }

    public string? AskLoadFile(params string[] extensions) => WinDialogs.AskLoadFile(extensions);
    public string? AskSaveFile(params string[] extensions) => WinDialogs.AskSaveFile(extensions);
    public string? AskPassword() => WinDialogs.AskPassword();

    public void ShowInfo(string message) => WinDialogs.ShowInfo(message);
    public void ShowWarning(string message) => WinDialogs.ShowWarning(message);
    public void ShowError(string message) => WinDialogs.ShowError(message);
    public bool AskConfirm(string message) => WinDialogs.AskConfirm(message);

    private void btnClear_Click(object sender, EventArgs e) => OnClearRequest?.Invoke();
    private void btnAddQuestion_Click(object sender, EventArgs e) => _questionView.CreateQuestionOnTail(inspire: false);
    private void btnInspireQuestion_Click(object sender, EventArgs e) => _questionView.CreateQuestionOnTail(inspire: true);
    private void btnLoad_Click(object sender, EventArgs e) => OnLoadRequest?.Invoke();
    private void btnSave_Click(object sender, EventArgs e) => OnSaveRequest?.Invoke();
    private void txbTitle_TextChanged(object sender, EventArgs e) => OnTitleChange?.Invoke(tbxTitle.Text);
}
