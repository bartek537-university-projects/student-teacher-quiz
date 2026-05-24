using QuizApp.Core.Domain;
using System.ComponentModel;
using System.Data;

namespace QuizApp.Student.Presentation.QuizSession;

public partial class AnswerList : UserControl
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public IReadOnlyList<Answer> Answers
    {
        get;
        set { field = value; UpdateAnswerList(); }
    } = [];

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public IReadOnlyList<Answer> SelectedAnswers
    {
        get => GetSelectedAnswers();
        set => SetSelectedAnswers(value);
    }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool Marked
    {
        get;
        set { field = value; UpdateColorMarking(); }
    }

    public event Action? SelectedAnswersChanged;

    public AnswerList()
    {
        InitializeComponent();
    }

    private void UpdateAnswerList()
    {
        SuspendLayout();

        Controls.Clear();

        foreach (Answer answer in Answers.Reverse())
        {
            CheckBox checkbox = CreateAnswerCheckbox(answer);
            checkbox.CheckedChanged += OnAnswerCheckedChanged;
            Controls.Add(checkbox);
        }

        UpdateColorMarking();

        ResumeLayout();
    }

    private CheckBox CreateAnswerCheckbox(Answer answer)
    {
        const int margin = 3;
        const int padding = 8;

        CheckBox checkbox = new()
        {
            Appearance = Appearance.Button,
            AutoEllipsis = true,
            Dock = DockStyle.Top,
            Margin = new Padding(margin),
            Padding = new Padding(padding),
            Parent = this,
            Tag = answer,
            Text = answer.Title,
            UseVisualStyleBackColor = true,
        };

        checkbox.Height = (2 * margin) + (2 * padding) + checkbox.Font.Height;

        return checkbox;
    }

    private void OnAnswerCheckedChanged(object? sender, EventArgs e)
    {
        SelectedAnswersChanged?.Invoke();
    }

    private IReadOnlyList<Answer> GetSelectedAnswers()
    {
        return [.. Controls.OfType<CheckBox>()
            .Where(it => it.Checked)
            .Select(it => it.Tag as Answer)
            .OfType<Answer>()];
    }

    private void SetSelectedAnswers(IReadOnlyList<Answer> selectedAnswers)
    {
        foreach (CheckBox checkbox in Controls.OfType<CheckBox>())
        {
            if (checkbox.Tag is not Answer answer)
            {
                continue;
            }
            checkbox.Checked = selectedAnswers.Contains(answer);
        }
    }

    private void UpdateColorMarking()
    {
        foreach (CheckBox checkbox in Controls.OfType<CheckBox>())
        {
            if (checkbox.Tag is not Answer answer)
            {
                continue;
            }

            Color color = Marked
                ? GetAnswerColor(checkbox.Checked, answer.IsCorrect)
                : Color.Empty;

            checkbox.BackColor = color;
            checkbox.UseVisualStyleBackColor = color == Color.Empty;
        }
    }

    private Color GetAnswerColor(bool isChecked, bool isCorrect)
    {
        return (isChecked, isCorrect) switch
        {
            (true, true) => Color.FromArgb(213, 245, 227),
            (true, false) => Color.FromArgb(242, 212, 209),
            (false, true) => Color.FromArgb(234, 250, 244),
            _ => Color.Empty,
        };
    }
}
