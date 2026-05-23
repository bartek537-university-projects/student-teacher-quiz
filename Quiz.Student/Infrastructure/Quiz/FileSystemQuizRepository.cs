using QuizApp.Student.Application.Quiz.Abstractions;
using System.Text.Json;
using DomainQuiz = QuizApp.Core.Domain.Quiz;

namespace QuizApp.Student.Infrastructure.Quiz;

internal class FileSystemQuizRepository : IQuizRepository
{
    public Task<DomainQuiz?> GetSingleAsync(Uri path, string? secret)
    {
        DomainQuiz? quiz = ReadQuiz(path);
        return Task.FromResult(quiz);
    }

    private static DomainQuiz? ReadQuiz(Uri uri)
    {
        string path = uri.AbsolutePath;

        if (!File.Exists(path))
        {
            return null;
        }

        try
        {
            string json = File.ReadAllText(path);
            return JsonSerializer.Deserialize<DomainQuiz>(json);
        }
        catch
        {
            return null;
        }
    }
}