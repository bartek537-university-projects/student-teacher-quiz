using DomainQuiz = QuizApp.Core.Domain.Quiz;

namespace QuizApp.Student.Application.Quiz.Abstractions;

public interface IQuizRepository
{
    Task<DomainQuiz?> GetSingleAsync(Uri path, string? secret);
}
