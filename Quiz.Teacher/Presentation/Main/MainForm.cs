using System.Collections.Immutable;
using QuizApp.Core.Domain;
using QuizApp.Teacher.View;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class MainForm : Form, IEditorView, IQuizView, IQuestionView, IAnswerView
{
    private readonly List<QuestionEditorControl> _questionControls = [];
    private int? _highlightedQuestionIndex;

    public event Action? OnLoadRequest;
    public event Action? OnSaveRequest;
    public event Action<string>? OnQuizTitleChange;
    public event Action? OnClear;
    public event Action<int>? OnQuestionAdd;
    public event Action<int, string>? OnQuestionTitleChange;
    public event Action<int, int> OnQuestionPlusPointsChange;
    public event Action<int, int> OnQuestionMinusPointsChange;
    public event Action<int>? OnQuestionRemove;
    public event Action<int>? OnQuestionMoveDown;
    public event Action<int>? OnQuestionMoveUp;
    public event Action<int, int>? OnAnswerAdd;
    public event Action<int, int, string>? OnAnswerTitleChange;
    public event Action<int, int, bool>? OnAnswerIsCorrectChange;
    public event Action<int, int>? OnAnswerRemove;
    public event Action<int, int>? OnAnswerMoveDown;
    public event Action<int, int>? OnAnswerMoveUp;

    private Quiz _quiz = new(QuizApp.Teacher.Properties.Resources.DefaultQuizTitle, []);

    public Quiz Quiz
    {
        get => _quiz;
        set
        {
            ArgumentNullException.ThrowIfNull(value);
            _quiz = value;
            UpdateFromQuiz();
        }
    }

    public MainForm(
        out IEditorView editorView,
        out IQuizView quizView,
        out IQuestionView questionView,
        out IAnswerView answerView
        )
    {
        InitializeComponent();

        editorView = this;
        quizView = this;
        questionView = this;
        answerView = this;

        Text = QuizApp.Teacher.Properties.Resources.AppTitle;
        txtQuizTitle.Text = _quiz.Title;

        btnLoad.Click += (_, _) => OnLoadRequest?.Invoke();
        btnSave.Click += (_, _) => OnSaveRequest?.Invoke();
        btnClear.Click += (_, _) => OnClear?.Invoke();
        btnAddQuestion.Click += (_, _) => OnQuestionAdd?.Invoke(Quiz.Questions.Length);
        txtQuizTitle.TextChanged += QuizTitleTextChanged;

        UpdateFromQuiz();
    }

    private void Form1_Load(object sender, EventArgs e)
    {

    }

    public void ShowValidationProblems(string message, int? questionIndex)
    {
        _highlightedQuestionIndex = questionIndex;
        UpdateQuestionHighlighting();
        MessageBox.Show(this, message, QuizApp.Teacher.Properties.Resources.ValidationProblemTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public string AskLoadFile()
    {
        using var dialog = new OpenFileDialog
        {
            Title = QuizApp.Teacher.Properties.Resources.LoadDialogTitle,
            Filter = QuizApp.Teacher.Properties.Resources.QuizFileFilter,
            CheckFileExists = true
        };

        return dialog.ShowDialog(this) == DialogResult.OK ? dialog.FileName : string.Empty;
    }

    public string AskSaveFile()
    {
        using var dialog = new SaveFileDialog
        {
            Title = QuizApp.Teacher.Properties.Resources.SaveDialogTitle,
            Filter = QuizApp.Teacher.Properties.Resources.QuizFileFilter,
            OverwritePrompt = true
        };

        return dialog.ShowDialog(this) == DialogResult.OK ? dialog.FileName : string.Empty;
    }

    public string AskPassword()
    {
        using var dialog = new PasswordDialog();
        return dialog.ShowDialog(this) == DialogResult.OK ? dialog.Password : string.Empty;
    }

    public void ShowInfo(string message)
    {
        MessageBox.Show(this, message, QuizApp.Teacher.Properties.Resources.InfoTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
    }


    public void ShowWarning(string message)
    {
        MessageBox.Show(this, message, QuizApp.Teacher.Properties.Resources.WarningTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public void ShowError(string message)
    {
        MessageBox.Show(this, message, QuizApp.Teacher.Properties.Resources.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    private void UpdateFromQuiz()
    {
        txtQuizTitle.TextChanged -= QuizTitleTextChanged;
        txtQuizTitle.Text = _quiz.Title;
        txtQuizTitle.TextChanged += QuizTitleTextChanged;

        RebuildQuestions(_quiz.Questions);
    }

    private void QuizTitleTextChanged(object? sender, EventArgs e)
    {
        OnQuizTitleChange?.Invoke(txtQuizTitle.Text);
    }

    private void RebuildQuestions(ImmutableArray<Question> questions)
    {
        flpQuestions.SuspendLayout();
        try
        {
            foreach (var control in _questionControls)
            {
                flpQuestions.Controls.Remove(control);
                control.Dispose();
            }

            _questionControls.Clear();

            for (int i = 0; i < questions.Length; i++)
            {
                var questionControl = new QuestionEditorControl();
                questionControl.Bind(i, questions[i]);
                HookQuestionEvents(questionControl, i);
                questionControl.Width = flpQuestions.ClientSize.Width - 8;
                questionControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                flpQuestions.Controls.Add(questionControl);
                _questionControls.Add(questionControl);
            }
        }
        finally
        {
            flpQuestions.ResumeLayout();
        }

        UpdateQuestionHighlighting();
    }

    private void HookQuestionEvents(QuestionEditorControl control, int questionIndex)
    {
        control.OnTitleChanged += title => OnQuestionTitleChange?.Invoke(questionIndex, title);
        control.OnPlusPointsChanged += points => OnQuestionPlusPointsChange?.Invoke(questionIndex, points);
        control.OnMinusPointsChanged += points => OnQuestionMinusPointsChange?.Invoke(questionIndex, points);
        control.OnRemove += () => OnQuestionRemove?.Invoke(questionIndex);
        control.OnMoveDown += () => OnQuestionMoveDown?.Invoke(questionIndex);
        control.OnMoveUp += () => OnQuestionMoveUp?.Invoke(questionIndex);
        control.OnAddAnswer += () => OnAnswerAdd?.Invoke(questionIndex, _quiz.Questions[questionIndex].Answers.Length);
        control.OnAnswerTitleChanged += (i0, i1, title) => OnAnswerTitleChange?.Invoke(i0, i1, title);
        control.OnAnswerIsCorrectChanged += (i0, i1, isCorrect) => OnAnswerIsCorrectChange?.Invoke(i0, i1, isCorrect);
        control.OnAnswerRemove += (i0, i1) => OnAnswerRemove?.Invoke(i0, i1);
        control.OnAnswerMoveDown += (i0, i1) => OnAnswerMoveDown?.Invoke(i0, i1);
        control.OnAnswerMoveUp += (i0, i1) => OnAnswerMoveUp?.Invoke(i0, i1);
    }

    private void UpdateQuestionHighlighting()
    {
        for (int i = 0; i < _questionControls.Count; i++)
        {
            bool isError = _highlightedQuestionIndex.HasValue && _highlightedQuestionIndex.Value == i;
            _questionControls[i].HighlightError(isError);
        }
    }
}
