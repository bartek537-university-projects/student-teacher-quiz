using QuizApp.Core.Domain;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class QuestionEditorControl : UserControl
{
    public event Action? OnMoveUp;
    public event Action? OnMoveDown;
    public event Action? OnRemove;
    public event Action? OnAddAnswer;
    public event Action<string>? OnTitleChanged;
    public event Action<int>? OnPlusPointsChanged;
    public event Action<int>? OnMinusPointsChanged;

    public event Action<int, int, string>? OnAnswerTitleChanged;
    public event Action<int, int, bool>? OnAnswerIsCorrectChanged;
    public event Action<int, int>? OnAnswerRemove;
    public event Action<int, int>? OnAnswerMoveDown;
    public event Action<int, int>? OnAnswerMoveUp;

    private int _questionIndex;
    private readonly List<AnswerEditorControl> _answerControls = [];

    public QuestionEditorControl()
    {
        InitializeComponent();
    }

    public void Bind(int questionIndex, Question question)
    {
        _questionIndex = questionIndex;
        lblQuestionTitle.Text = string.Format(QuizApp.Teacher.Properties.Resources.QuestionLabelFormat, questionIndex + 1);
        txtQuestionTitle.Text = question.Title;
        nudPlusPoints.Value = question.PlusPoints;
        nudMinusPoints.Value = question.MinusPoints;

        RebuildAnswers(question.Answers);
    }

    public void HighlightError(bool isError)
    {
        pnlHeader.BackColor = isError ? Color.MistyRose : SystemColors.Control;
        pnlBody.BackColor = isError ? Color.MistyRose : SystemColors.Control;
    }

    private void RebuildAnswers(IReadOnlyList<Answer> answers)
    {
        flpAnswers.SuspendLayout();
        try
        {
            foreach (var control in _answerControls)
            {
                flpAnswers.Controls.Remove(control);
                control.Dispose();
            }

            _answerControls.Clear();

            for (int i = 0; i < answers.Count; i++)
            {
                var answerControl = new AnswerEditorControl();
                answerControl.Bind(_questionIndex, i, answers[i]);
                HookAnswerEvents(answerControl, i);
                answerControl.Width = flpAnswers.ClientSize.Width - 8;
                answerControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
                flpAnswers.Controls.Add(answerControl);
                _answerControls.Add(answerControl);
            }
        }
        finally
        {
            flpAnswers.ResumeLayout();
        }
    }

    private void HookAnswerEvents(AnswerEditorControl control, int answerIndex)
    {
        control.OnTitleChanged += title => OnAnswerTitleChanged?.Invoke(_questionIndex, answerIndex, title);
        control.OnIsCorrectChanged += isCorrect => OnAnswerIsCorrectChanged?.Invoke(_questionIndex, answerIndex, isCorrect);
        control.OnRemove += () => OnAnswerRemove?.Invoke(_questionIndex, answerIndex);
        control.OnMoveDown += () => OnAnswerMoveDown?.Invoke(_questionIndex, answerIndex);
        control.OnMoveUp += () => OnAnswerMoveUp?.Invoke(_questionIndex, answerIndex);
    }

    private void TxtQuestionTitle_TextChanged(object sender, EventArgs e)
    {
        OnTitleChanged?.Invoke(txtQuestionTitle.Text);
    }

    private void NudPlusPoints_ValueChanged(object sender, EventArgs e)
    {
        OnPlusPointsChanged?.Invoke((int)nudPlusPoints.Value);
    }

    private void NudMinusPoints_ValueChanged(object sender, EventArgs e)
    {
        OnMinusPointsChanged?.Invoke((int)nudMinusPoints.Value);
    }

    private void BtnAddAnswer_Click(object sender, EventArgs e)
    {
        OnAddAnswer?.Invoke();
    }

    private void BtnMoveUp_Click(object sender, EventArgs e)
    {
        OnMoveUp?.Invoke();
    }

    private void BtnMoveDown_Click(object sender, EventArgs e)
    {
        OnMoveDown?.Invoke();
    }

    private void BtnRemove_Click(object sender, EventArgs e)
    {
        OnRemove?.Invoke();
    }
}
