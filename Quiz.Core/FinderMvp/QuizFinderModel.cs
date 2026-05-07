using QuizApp.Core.Domain;
using QuizApp.Core.Repositories;
using QuizApp.Core.Services.Encryption;

namespace QuizApp.Core.FinderMvp;

public interface IQuizFinderModel
{
    List<string> AllQuizNames();
    Task<Quiz?> ObtainQuizAsync(string name, string password);
    Task SaveQuizAsync(string name, string password, Quiz quiz);
    void DeleteQuiz(string name);
}

public class QuizFinderModel(string directory) : IQuizFinderModel
{
    private readonly QuizRepository _quizes = new(directory);

    public List<string> AllQuizNames()
    {
        return _quizes.AllQuizNames();
    }

    public async Task<Quiz?> ObtainQuizAsync(string name, string password)
    {
        using var key = await KeyFactory.AesFromPassword(password);
        return _quizes.ReadQuiz(name, key);
    }

    public async Task SaveQuizAsync(string name, string password, Quiz quiz)
    {
        using var key = await KeyFactory.AesFromPassword(password);
        _quizes.SaveQuiz(name, key, quiz);
    }

    public void DeleteQuiz(string name)
    {
        _quizes.DeleteQuiz(name);
    }
}
