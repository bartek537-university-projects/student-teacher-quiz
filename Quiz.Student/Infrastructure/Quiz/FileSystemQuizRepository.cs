using QuizApp.Core.Model;
using QuizApp.Student.Application.Quiz.Abstractions;
using DomainQuiz = QuizApp.Core.Domain.Quiz;

namespace QuizApp.Student.Infrastructure.Quiz;

internal class FileSystemQuizRepository(IQuizAccessor quizAccessor) : IQuizRepository
{
    public async Task<DomainQuiz?> GetSingleAsync(Uri uri, string? secret, CancellationToken _)
    {
        string path = uri.AbsolutePath;

        if (!File.Exists(path))
        {
            return null;
        }

        try
        {
            return await quizAccessor.LoadFromFile(uri.AbsolutePath, secret ?? "");
        }
        catch
        {
            return null;
        }
    }
}