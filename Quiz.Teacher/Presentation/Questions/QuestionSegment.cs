using QuizApp.Core.Domain;

namespace QuizApp.Teacher.Presentation.Main;

internal partial class QuestionSegment : UserControl
{
    public Guid Guid { get; set; }

    public string Title
    {
        get => tbxTitle.Text;
        set => tbxTitle.Text = lbAutoTitle.Text = value;
    }

    public int PlusPoints
    {
        get => int.TryParse(tbxPlusPoints.Text, out int value) ? value : value;
        set => tbxPlusPoints.Text = value.ToString();
    }

    public int MinusPoints
    {
        get => int.TryParse(tbxMinusPoints.Text, out int value) ? value : value;
        set => tbxMinusPoints.Text = value.ToString();
    }

    public bool ButtonUpEnabled
    {
        get => btnUp.Enabled;
        set => btnUp.Enabled = value;
    }

    public bool ButtonDownEnabled
    {
        get => btnDown.Enabled;
        set => btnDown.Enabled = value;
    }

    public bool ButtonNewEnabled
    {
        get => btNew.Enabled;
        set => btNew.Enabled = value;
    }

    public bool ButtonDeleteEnabled
    {
        get => btnDelete.Enabled;
        set => btnDelete.Enabled = value;
    }

    public bool PlusPointsEnabled
    {
        get => cbxPlusPoints.Checked;
        set => cbxPlusPoints.Checked = tbxPlusPoints.Enabled = value;
    }

    public bool MinusPointsEnabled
    {
        get => cbxMinusPoints.Checked;
        set => cbxMinusPoints.Checked = tbxMinusPoints.Enabled = value;
    }

    public event Action<string>? OnTitleChange;
    public event Action<int>? OnPlusPointsChange;
    public event Action<int>? OnMinusPointsChange;

    public event Action? OnNew;
    public event Action? OnDelete;
    public event Action? OnMoveUp;
    public event Action? OnMoveDown;

    private readonly Color _backColor;
    private bool _firstLoad = true;

    public QuestionSegment()
    {
        InitializeComponent();

        Title = "";
        PlusPoints = 0;
        MinusPoints = 0;
        PlusPointsEnabled = false;
        MinusPointsEnabled = false;
        ButtonUpEnabled = false;
        ButtonDownEnabled = false;
        ButtonNewEnabled = false;
        ButtonDeleteEnabled = false;

        _backColor = BackColor;

        RefreshCheckboxes();
    }

    public void RefreshView(Question question, bool isFirst, bool isLast)
    {
        Title = question.Title;

        PlusPoints = question.PlusPoints;
        MinusPoints = question.MinusPoints;

        if (_firstLoad)
        {
            PlusPointsEnabled = question.PlusPoints != 0;
            MinusPointsEnabled = question.MinusPoints != 0;

            _firstLoad = false;
        }

        ButtonUpEnabled = !isFirst;
        ButtonDownEnabled = !isLast;
        ButtonNewEnabled = true;
        ButtonDeleteEnabled = true;

        BackColor = _backColor;
    }

    private void RefreshCheckboxes()
    {
        tbxPlusPoints.Enabled = cbxPlusPoints.Checked;
        tbxMinusPoints.Enabled = cbxMinusPoints.Checked;
    }

    public void HighlightError()
    {
        BackColor = Color.Pink;
    }

    public Panel GetPanel()
    {
        return pnAnswers;
    }

    private void imagineOnlyNumbers_KeyPress(object sender, KeyPressEventArgs e)
    {
        if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
        {
            e.Handled = true;
        }
    }

    private void cbxPlusPoints_CheckedChanged(object sender, EventArgs e)
    {
        if (!cbxPlusPoints.Checked)
            OnPlusPointsChange?.Invoke(0);

        RefreshCheckboxes();
    }

    private void cbxMinusPoints_CheckedChanged(object sender, EventArgs e)
    {
        if (!cbxMinusPoints.Checked)
            OnMinusPointsChange?.Invoke(0);

        RefreshCheckboxes();
    }

    private void tbxTitle_TextChanged(object sender, EventArgs e) => OnTitleChange?.Invoke(Title);
    private void tbxPlusPoints_TextChanged(object sender, EventArgs e) => OnPlusPointsChange?.Invoke(PlusPoints);
    private void tbxMinusPoints_TextChanged(object sender, EventArgs e) => OnMinusPointsChange?.Invoke(MinusPoints);

    private void btNew_Click(object sender, EventArgs e) => OnNew?.Invoke();
    private void btnDelete_Click(object sender, EventArgs e) => OnDelete?.Invoke();
    private void btnUp_Click(object sender, EventArgs e) => OnMoveUp?.Invoke();
    private void btnDown_Click(object sender, EventArgs e) => OnMoveDown?.Invoke();
}
