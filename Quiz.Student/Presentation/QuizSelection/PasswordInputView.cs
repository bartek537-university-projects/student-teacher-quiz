using System.ComponentModel;

namespace QuizApp.Student.Presentation.QuizSelection;

public partial class PasswordInputView : Form
{
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public Uri? Path { get; set; }
    [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
    public string Password { get => tbPassword.Text; set => tbPassword.Text = value; }

    [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
    public bool IsInvalid { set => SetIsInvalid(value); }

    public event Action? SubmitClick;

    public PasswordInputView()
    {
        InitializeComponent();
    }

    private void btnUnlock_Click(object sender, EventArgs e)
    {
        SubmitClick?.Invoke();
    }

    private void SetIsInvalid(bool isInvalid)
    {
        lbError.Visible = isInvalid;
    }
}
