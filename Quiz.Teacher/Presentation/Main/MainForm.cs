using QuizApp.Core.Domain;
using QuizApp.Teacher.Presentation.WinHelpers;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class MainForm : Form, IEditorView
{
    public Quiz Quiz
    {
        get => field;
        set
        {
            if ((field = value) != null)
            {
                RefreshView();
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

        Quiz = null!; // temporary, presenter will overwrite it

        editorView = this;
        questionView = _questionView = new QuestionView(this, pnQuestions);
        answerView = _answerView = new AnswerView(this, _questionView.PanelIndexer);
    }

    private void MainForm_Load(object? sender, EventArgs e)
    {
        OnClearInstant?.Invoke();
    }

    private void RefreshView()
    {
        tbxTitle.Text = Quiz.Title;
        _questionView.RefreshView();
        _answerView.RefreshView();
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

    private void btnLoad_Click(object? sender, EventArgs e) => OnLoadRequest?.Invoke();
    private void btnSave_Click(object? sender, EventArgs e) => OnSaveRequest?.Invoke();
    private void btnClear_Click(object sender, EventArgs e) => OnClearRequest?.Invoke();
    private void txbTitle_TextChanged(object sender, EventArgs e) => OnTitleChange?.Invoke(tbxTitle.Text);
}
