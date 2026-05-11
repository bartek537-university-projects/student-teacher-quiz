namespace QuizApp.Teacher.Presentation.WinHelpers;

internal static partial class WinDialogs
{
    public static string? AskLoadFile(params string[] extensions)
    {
        using var openFileDialog = new OpenFileDialog()
        {
            Title = "Wybierz plik do otwarcia",
            Filter = CreateFilter(extensions)
        };

        return openFileDialog.ShowDialog() == DialogResult.OK
            ? openFileDialog.FileName
            : null;
    }

    public static string? AskSaveFile(params string[] extensions)
    {
        using var saveFileDialog = new SaveFileDialog()
        {
            Title = "Zapisz plik jako",
            Filter = CreateFilter(extensions),
            AddExtension = true,
            DefaultExt = extensions.FirstOrDefault()
        };

        return saveFileDialog.ShowDialog() == DialogResult.OK
            ? saveFileDialog.FileName
            : null;
    }

    private static string CreateFilter(string[] extensions)
    {
        if (extensions.Length == 0)
            return "Wszystkie pliki (*.*)|*.*";

        return string.Join('|',
            extensions.Select(ext =>
                $"{ext.ToUpper()} files (*.{ext})|*.{ext}")) +
            "|Wszystkie pliki (*.*)|*.*";
    }
}
