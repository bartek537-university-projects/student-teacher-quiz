using QuizApp.Core.Domain;
using QuizApp.Core.Services.Encryption;
using QuizApp.Core.Services.Serialization;

namespace QuizApp.Core.Repositories;

internal class QuizRepository(string directory)
{
    private readonly List<string> _quizNames = [];

    public List<string> AllQuizNames()
    {
        var files = Directory.EnumerateFiles(directory)
            .Where(file => !file.StartsWith('_'));

        _quizNames.Clear();
        _quizNames.AddRange(files);

        return _quizNames[..];
    }

    public Quiz ReadQuiz(string name, IEncryptionKey key)
    {
        string text = FileManager.Read(directory, name) ??
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
        FileManager.Write(directory, name, text);
    }

    public void DeleteQuiz(string name)
    {
        FileManager.Delete(directory, name);
    }
}
