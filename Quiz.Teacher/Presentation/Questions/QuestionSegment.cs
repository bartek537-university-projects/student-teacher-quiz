using QuizApp.Core.Domain;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class QuestionSegment : UserControl
{
    public required Guid Guid { get; init; }
    public Panel Panel => pnAnswers;

    public event Action<string>? OnTitleChange;
    public event Action<int>? OnPlusPointsChange;
    public event Action<int>? OnMinusPointsChange;

    public event Action? OnCopy;
    public event Action? OnDelete;
    public event Action? OnMoveUp;
    public event Action? OnMoveDown;

    public QuestionSegment()
    {
        InitializeComponent();
    }

    public void RefreshView(Question question, int index)
    {
        lbAutoTitle.Text = $"Pytanie {index + 1}";
        tbxTitle.Text = question.Title;
        tbxPlusPoints.Text = question.PlusPoints.ToString();
        tbxMinusPoints.Text = question.MinusPoints.ToString();
    }

    public void HighlightError()
    {
        BackColor = Color.LightPink; // TEMPORARY
    }

    private void tbxTitle_TextChanged(object sender, EventArgs e)
    {
        string title = tbxTitle.Text;
        OnTitleChange?.Invoke(title);
    }

    private void tbxPlusPoints_TextChanged(object sender, EventArgs e)
    {
        int plusPoints = int.TryParse(tbxPlusPoints.Text, out var value) ? value : 0;
        OnPlusPointsChange?.Invoke(plusPoints);
    }

    private void tbxMinusPoints_TextChanged(object sender, EventArgs e)
    {
        int minusPoints = int.TryParse(tbxMinusPoints.Text, out var value) ? value : 0;
        OnMinusPointsChange?.Invoke(minusPoints);
    }

    private void btCopy_Click(object sender, EventArgs e) => OnCopy?.Invoke();
    private void btnDelete_Click(object sender, EventArgs e) => OnDelete?.Invoke();
    private void btnUp_Click(object sender, EventArgs e) => OnMoveUp?.Invoke();
    private void btnDown_Click(object sender, EventArgs e) => OnMoveDown?.Invoke();
}
