namespace QuizApp.Teacher.Presentation.WinHelpers;

internal static partial class WinDialogs
{
    public static void ShowInfo(string message)
    {
        MessageBox.Show(message, "Informacja", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    public static void ShowWarning(string message)
    {
        MessageBox.Show(message, "Ostrzeżenie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }

    public static void ShowError(string message)
    {
        MessageBox.Show(message, "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }

    public static bool AskConfirm(string message)
    {
        DialogResult result = MessageBox.Show(message, "Potwierdzenie", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        return result == DialogResult.Yes;
    }
}
