namespace QuizApp.Teacher.Presentation.Main;

internal sealed class PasswordDialog : Form
{
    private readonly TextBox _txtPassword;
    private readonly Button _btnOk;
    private readonly Button _btnCancel;

    public PasswordDialog()
    {
        Text = QuizApp.Teacher.Properties.Resources.PasswordDialogTitle;
        FormBorderStyle = FormBorderStyle.FixedDialog;
        StartPosition = FormStartPosition.CenterParent;
        MinimizeBox = false;
        MaximizeBox = false;
        ShowInTaskbar = false;
        AutoSize = true;
        AutoSizeMode = AutoSizeMode.GrowOnly;

        var lbl = new Label
        {
            Text = QuizApp.Teacher.Properties.Resources.PasswordLabel,
            AutoSize = true,
            Margin = new Padding(12, 12, 12, 0)
        };

        _txtPassword = new TextBox
        {
            UseSystemPasswordChar = true,
            Width = 240,
            Margin = new Padding(12, 6, 12, 12)
        };

        _btnOk = new Button
        {
            Text = QuizApp.Teacher.Properties.Resources.OkButtonText,
            DialogResult = DialogResult.OK,
            Margin = new Padding(6)
        };

        _btnCancel = new Button
        {
            Text = QuizApp.Teacher.Properties.Resources.CancelButtonText,
            DialogResult = DialogResult.Cancel,
            Margin = new Padding(6)
        };

        AcceptButton = _btnOk;
        CancelButton = _btnCancel;

        var buttonPanel = new FlowLayoutPanel
        {
            FlowDirection = FlowDirection.RightToLeft,
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowOnly,
            Padding = new Padding(6)
        };

        buttonPanel.Controls.Add(_btnCancel);
        buttonPanel.Controls.Add(_btnOk);

        var layout = new TableLayoutPanel
        {
            Dock = DockStyle.Fill,
            AutoSize = true,
            AutoSizeMode = AutoSizeMode.GrowOnly,
            ColumnCount = 1,
            RowCount = 3
        };

        layout.Controls.Add(lbl, 0, 0);
        layout.Controls.Add(_txtPassword, 0, 1);
        layout.Controls.Add(buttonPanel, 0, 2);

        Controls.Add(layout);
    }

    public string Password => _txtPassword.Text;
}
