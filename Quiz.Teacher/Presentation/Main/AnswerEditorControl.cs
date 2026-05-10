using QuizApp.Core.Domain;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class AnswerEditorControl : UserControl
{
    public event Action? OnMoveUp;
    public event Action? OnMoveDown;
    public event Action? OnRemove;
    public event Action<string>? OnTitleChanged;
    public event Action<bool>? OnIsCorrectChanged;

    private int _questionIndex;
    private int _answerIndex;

    public AnswerEditorControl()
    {
        InitializeComponent();
    }

    public void Bind(int questionIndex, int answerIndex, Answer answer)
    {
        _questionIndex = questionIndex;
        _answerIndex = answerIndex;

        txtAnswerTitle.Text = answer.Title;
        chkIsCorrect.Checked = answer.IsCorrect;
    }

    private void TxtAnswerTitle_TextChanged(object sender, EventArgs e)
    {
        OnTitleChanged?.Invoke(txtAnswerTitle.Text);
    }

    private void ChkIsCorrect_CheckedChanged(object sender, EventArgs e)
    {
        OnIsCorrectChanged?.Invoke(chkIsCorrect.Checked);
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
