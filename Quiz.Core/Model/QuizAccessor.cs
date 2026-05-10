using QuizApp.Core.Domain;
using QuizApp.Core.Services.Encryption;
using QuizApp.Core.Services.Files;
using QuizApp.Core.Services.Serialization;

namespace QuizApp.Core.Model;

public interface IQuizAccessor
{
    Task<Quiz> LoadFromFile(string filepath, string password);
    Task SaveToFile(string filepath, string password, Quiz quiz);
}

public class QuizAccessor : IQuizAccessor
{
    public async Task<Quiz> LoadFromFile(string filepath, string password)
    {
        string text = FileHelpers.ReadAllText(filepath);

        byte[] encrypted = Convert.FromBase64String(text);

        var key = await KeyFactory.AesFromPassword(password);
        byte[] bytes = key.Decrypt(encrypted);

        return Serializer.Deserialize<Quiz>(bytes);
    }

    public async Task SaveToFile(string filepath, string password, Quiz quiz)
    {
        byte[] bytes = Serializer.Serialize(quiz);

        var key = await KeyFactory.AesFromPassword(password);
        byte[] encrypted = key.Encrypt(bytes);

        string text = Convert.ToBase64String(encrypted);

        FileHelpers.WriteAtomic(filepath, text);
    }
}
