namespace QuizApp.Teacher.Presentation.WinHelpers;

internal static partial class WinDialogs
{
    public static string? AskPassword()
    {
        using var prompt = new Form()
        {
            Width = 300,
            Height = 150,
            FormBorderStyle = FormBorderStyle.FixedDialog,
            Text = "Podanie hasła wymagane...",
            StartPosition = FormStartPosition.CenterScreen,
            MaximizeBox = false,
            MinimizeBox = false,
        };

        var textLabel = new Label()
        {
            Left = 20,
            Top = 20,
            Text = "Podaj hasło:"
        };

        var inputBox = new TextBox()
        {
            Left = 20,
            Top = 45,
            Width = 240,
            UseSystemPasswordChar = true
        };

        var confirmation = new Button()
        {
            Text = "OK",
            Left = 160,
            Width = 100,
            Top = 75,
            DialogResult = DialogResult.OK
        };

        prompt.AcceptButton = confirmation;

        prompt.Controls.Add(textLabel);
        prompt.Controls.Add(inputBox);
        prompt.Controls.Add(confirmation);

        if (prompt.ShowDialog() == DialogResult.OK)
        {
            return inputBox.Text;
        }

        return null;
    }
}
