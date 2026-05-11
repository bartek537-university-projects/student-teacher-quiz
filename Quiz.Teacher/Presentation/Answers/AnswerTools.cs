namespace QuizApp.Teacher.Presentation.Main;

internal partial class AnswerTools : UserControl
{
    public Guid Guid { get; set; }

    public bool AddEnabled
    {
        get => btAdd.Enabled;
        set => btAdd.Enabled = value;
    }

    public bool RemoveEnabled
    {
        get => btRemove.Enabled;
        set => btRemove.Enabled = value;
    }

    public event Action? OnAdd;
    public event Action? OnRemove;

    private bool _isObserved;

    public AnswerTools()
    {
        InitializeComponent();

        AddEnabled = false;
        RemoveEnabled = false;
    }

    public bool AllowObservation()
    {
        if (!_isObserved)
            return _isObserved = true;
        return false;
    }

    public void RefreshView(int count)
    {
        AddEnabled = true;
        RemoveEnabled = count > 0;
    }

    private void btAdd_Click(object sender, EventArgs e) => OnAdd?.Invoke();
    private void btRemove_Click(object sender, EventArgs e) => OnRemove?.Invoke();
}
