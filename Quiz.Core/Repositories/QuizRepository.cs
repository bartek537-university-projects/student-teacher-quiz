using QuizApp.Core.Domain;
using QuizApp.Core.Services;
using QuizApp.Core.Services.Encryption;
using QuizApp.Core.Services.Serialization;

namespace QuizApp.Core.Repositories;

internal class QuizRepository
{
    private readonly string _directory;
    private readonly List<string> _quizNames = [];

    public QuizRepository(string directory)
    {
        _directory = directory;
        RefreshNames();
    }

    public void RefreshNames()
    {
        var files = Directory.EnumerateFiles(_directory)
            .Where(file => !file.StartsWith('_'));

        _quizNames.Clear();
        _quizNames.AddRange(files);
    }

    public Quiz ReadQuiz(string name, IEncryptionKey key)
    {
        string text = FileManager.Read(_directory, name) ??
            throw new ProblemException(typeof(QuizRepository), "file reading");

        byte[] encrypted = Convert.FromBase64String(text);
        byte[] bytes = key.Decrypt(encrypted);

        return Serializer.Deserialize<Quiz>(bytes);
    }

    public void SaveQuiz(string name, IEncryptionKey key, Quiz quiz)
    {
        byte[] bytes = Serializer.Serialize(quiz);
        byte[] encrypted = key.Encrypt(bytes);

        string text = Convert.ToBase64String(encrypted);
        FileManager.Write(_directory, name, text);
    }
}
