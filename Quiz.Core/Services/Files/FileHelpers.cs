namespace QuizApp.Core.Services.Files;

internal class FileHelpers
{
    public static string ReadAllText(string filepath)
    {
        return File.ReadAllText(filepath);
    }

    public static void WriteAtomic(string filepath, string text)
    {
        string tempFile = Path.GetTempFileName();

        using (var fs = new FileStream(tempFile,
            FileMode.CreateNew,
            FileAccess.Write,
            FileShare.None))
        {
            using var writer = new StreamWriter(fs);

            writer.Write(text);
            writer.Flush();

            fs.Flush(true);
        }

        File.Move(tempFile, filepath, true);
    }
}
