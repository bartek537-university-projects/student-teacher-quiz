using QuizApp.Core.Domain;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class MainForm : Form, IEditorView, IQuestionView, IAnswerView
{
    public event Action<string>? OnTitleChange;

    public event Action? OnClearRequest;
    public event Action? OnClearInstant;

    public event Action? OnLoadRequest;
    public event Action? OnSaveRequest;

    public Quiz Quiz
    {
        get => field;
        set
        {
            txbTitle.Text = value.Title;
            field = value;
        }
    }

    public MainForm(
        out IEditorView editorView,
        out IQuestionView questionView,
        out IAnswerView answerView
        )
    {
        InitializeComponent();

        Quiz = new Quiz("", []); // will be overriden by presenter

        editorView = this;
        questionView = this;
        answerView = this;
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        OnClearInstant?.Invoke();
    }

    // -------------------------------

    public void ShowValidationProblems(string message, int? questionIndex)
    {
        // TODO: make it more robust and user-friendly
        ShowError("TEMP ERROR BOX: " + message);
    }

    public string? AskLoadFile()
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Title = "Wybierz plik do otwarcia",
            Filter = "Wszystkie pliki (*.*)|*.*",
        };

        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            return openFileDialog.FileName;
        }

        return null;
    }

    public string? AskSaveFile()
    {
        using var saveFileDialog = new SaveFileDialog()
        {
            Title = "Zapisz plik jako",
            Filter = "Wszystkie pliki (*.*)|*.*"
        };

        if (saveFileDialog.ShowDialog() == DialogResult.OK)
        {
            return saveFileDialog.FileName;
        }

        return null;
    }

    public string? AskPassword()
    {
        // TODO: create a custom dialog

        using var prompt = new Form()
        {
            Width = 300,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "Wymagane podanie hasła...",
            StartPosition = FormStartPosition.CenterScreen,
            MaximizeBox = false,
            MinimizeBox = false,
        };

        var textLabel = new Label()
        {
            Left = 20,
            Top = 20,
            Text = "Podaj hasło:"
        };

        var inputBox = new TextBox()
        {
            Left = 20,
            Top = 45,
            Width = 240,
            UseSystemPasswordChar = true
        };

        var confirmation = new Button()
        {
            Text = "OK",
            Left = 160,
            Width = 100,
            Top = 75,
            DialogResult = DialogResult.OK
        };

        prompt.AcceptButton = confirmation;

        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(inputBox);
        prompt.Controls.Add(confirmation);

        if (prompt.ShowDialog() == DialogResult.OK)
        {
            return inputBox.Text;
        }

        return null;
    }

    public void ShowInfo(string message)
    {
        MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public void ShowWarning(string message)
    {
        MessageBox.Show(message, "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public bool AskConfirm(string message)
    {
        DialogResult result = MessageBox.Show(message, "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        return result == DialogResult.Yes;
    }

    // -------------------------------

    public event Action<int>? OnQuestionAdd;
    public event Action<int, string>? OnQuestionTitleChange;
    public event Action<int, int>? OnQuestionPlusPointsChange;
    public event Action<int, int>? OnQuestionMinusPointsChange;
    public event Action<int>? OnQuestionRemove;
    public event Action<int>? OnQuestionMoveDown;
    public event Action<int>? OnQuestionMoveUp;

    // -------------------------------

    public event Action<int, int>? OnAnswerAdd;
    public event Action<int, int, string>? OnAnswerTitleChange;
    public event Action<int, int, bool>? OnAnswerIsCorrectChange;
    public event Action<int, int>? OnAnswerRemove;
    public event Action<int, int>? OnAnswerMoveDown;
    public event Action<int, int>? OnAnswerMoveUp;

    // -------------------------------

    private void btnLoad_Click(object? sender, EventArgs e)
    {
        OnLoadRequest?.Invoke();
    }

    private void btnSave_Click(object? sender, EventArgs e)
    {
        OnSaveRequest?.Invoke();
    }

    private void txbTitle_TextChanged(object sender, EventArgs e)
    {
        string title = txbTitle.Text;
        OnTitleChange?.Invoke(title);
    }

    private void btnClear_Click(object sender, EventArgs e)
    {
        OnClearRequest?.Invoke();
    }
}
