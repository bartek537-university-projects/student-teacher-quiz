using QuizApp.Core.Domain;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class AnswerSegment : UserControl
{
    public Guid Guid { get; set; }

    public string Title
    {
        get => tbxTitle.Text;
        set => tbxTitle.Text = value;
    }

    public bool IsCorrect
    {
        get => cbxIsCorrect.Checked;
        set => cbxIsCorrect.Checked = value;
    }

    public event Action<string>? OnTitleChange;
    public event Action<bool>? OnIsCorrectChange;

    public AnswerSegment()
    {
        InitializeComponent();

        Title = "";
        IsCorrect = false;
    }

    public void RefreshView(Answer answer)
    {
        Title = answer.Title;
        IsCorrect = answer.IsCorrect;
    }

    private void tbxTitle_TextChanged(object sender, EventArgs e) => OnTitleChange?.Invoke(Title);
    private void cbxIsCorrect_CheckedChanged(object sender, EventArgs e) => OnIsCorrectChange?.Invoke(IsCorrect);
}
